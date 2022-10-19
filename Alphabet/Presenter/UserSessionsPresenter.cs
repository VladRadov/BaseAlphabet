using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

using Alphabet.Model;
using Alphabet.Service;
using Alphabet.View;
using Alphabet.UI;
using Alphabet.Data;
using System;
using System.Threading.Tasks;

namespace Alphabet.Presenter
{
    internal class UserSessionsPresenter
    {
        private IUserSessionsView _userSessionsView;

        private AuthorizationToDatabase _authorizationToDatabase;

        public UserSessionsPresenter(AuthorizationToDatabase authorizationToDatabase, IBaseVIew userSessionsView)
        {
            _authorizationToDatabase = authorizationToDatabase;
            _userSessionsView = (IUserSessionsView)userSessionsView;

            Subscribe();
        }

        public UserSessionsPresenter(IBaseVIew userSessionsView)
        {
            _userSessionsView = (IUserSessionsView)userSessionsView;

            Subscribe();
        }

        private void Subscribe()
        {
            _userSessionsView.CloseUserSessionEventHandler += ResetUserSession;
        }

        public void ChangeStateUserSession()
        {
            string levelMessage = "Info";
            string message = string.Empty;
            try
            {
                var nameColumn = _authorizationToDatabase.GetNameColumn(0);
                if (nameColumn == "Error")
                {
                    UserSessions.Instance.IsOpen = false;
                    UserSessions.Instance.User = new NotFoundUser();

                    var messageSql = _authorizationToDatabase.ParseTableResult(0, 0);
                    levelMessage = "Error";
                    message = messageSql;
                    _userSessionsView.ShowMessageBox(messageSql, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (nameColumn == "Attantion")
                {
                    var messageSql = _authorizationToDatabase.ParseTableResult(0, 0);
                    levelMessage = "Error";
                    message = messageSql;
                    _userSessionsView.ShowMessageBox(messageSql, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    var userId = int.Parse(_authorizationToDatabase.ParseTableResult(0, NameColumns.UserID));
                    var login = _authorizationToDatabase.ParseTableResult(0, NameColumns.Login);
                    var fio = _authorizationToDatabase.ParseTableResult(0, NameColumns.FIO);
                    var userGroupName = _authorizationToDatabase.ParseTableResult(0, NameColumns.UserGroup);

                    var permissionARMs = new SelectPermissionARMs(login);
                    permissionARMs.Execute();

                    List<ARM> arms = new List<ARM>();
                    ViewPermissionARMs(arms, permissionARMs);

                    UserSessions.Instance.IsOpen = true;
                    UserSessions.Instance.User = new User()
                    {
                        UserID = userId,
                        Login = login,
                        FIO = fio,
                        UserGroup = ManagerUsersGroup.FindUsersGroup(userGroupName, arms)
                    };
                    levelMessage = "Info";
                    message = "Сессия пользователя " + UserSessions.Instance.User.Login + " успешно открыта.";
                }

                _userSessionsView.ViewSessionStatus(UserSessions.Instance.User.UserGroup.Icon,
                                                             UserSessions.Instance.User.UserGroup.Name,
                                                             UserSessions.Instance.IsOpen ? Color.FromArgb(192, 255, 192) : Color.FromArgb(255, 192, 192));
            }
            catch (Exception exception)
            {
                levelMessage = "Error";
                message = "Ошибка открытия сессии пользователя! " + exception.ToString();
            }
            finally
            {
                Logger.Writer(new SQLWriteSystemLogger(
                    new AttributeSystemLog()
                    {
                        DateTimeCreate = DateTime.Now,
                        LevelMessage = levelMessage,
                        Message = message
                    }));
            }
        }

        public void ChangeStateLocalAdminSession()
        {
            string levelMessage = "Info";
            string message = string.Empty;
            try
            {
                var allARMs = new SelectAllArms();
                allARMs.Execute();


                List<ARM> arms = new List<ARM>();
                ViewPermissionARMs(arms, allARMs);

                UserSessions.Instance.IsOpen = true;
                UserSessions.Instance.User = new User()
                {
                    UserID = 0,
                    Login = Admin.Login,
                    FIO = Admin.Login
                };
                levelMessage = "Info";
                message = "Сессия пользователя " + UserSessions.Instance.User.Login + " успешно открыта.";
            }
            catch (Exception exception)
            {
                levelMessage = "Error";
                message = "Ошибка открытия сессии пользователя! " + exception.ToString();
            }
            finally
            {
                Logger.Writer(new SQLWriteSystemLogger(
                    new AttributeSystemLog()
                    {
                        DateTimeCreate = DateTime.Now,
                        LevelMessage = levelMessage,
                        Message = message
                    }));
            }
        }

        private void ViewPermissionARMs(List<ARM> arms, BaseQuery baseQuery)
        {
            var storagePanelsARMs = new StoragePanelsARMs();

            foreach (DataRow permissionARM in baseQuery.ParseTableResult())
            {
                var nameARM = permissionARM.ItemArray[0].ToString();
                var arm = ARMManager.EnterARM(nameARM);
                arms.Add(arm);

                storagePanelsARMs.AddItem(new PanelARM() { Arm = arm, ARMName = nameARM });
            }
            storagePanelsARMs.SetParent(_userSessionsView.ParentGroundOfARMs);
        }

        private async void ResetUserSession()
        {
            string levelMessage = "Info";
            string message = string.Empty;

            try
            {
                await Task.Run(() =>
                    {
                        var resetUserSession = new ResetUserSession(UserSessions.Instance.User.Login);
                        resetUserSession.Execute();
                        message = "Сессия пользователя " + UserSessions.Instance.User.Login + " успешно закрыта!";
                    });
            }
            catch (Exception exception)
            {
                levelMessage = "Error";
                message = "Ошибка закрытия сессии пользователя! " + exception.ToString();
            }
            finally
            {
                Logger.Writer(new SQLWriteSystemLogger(
                    new AttributeSystemLog()
                    {
                        DateTimeCreate = DateTime.Now,
                        LevelMessage = levelMessage,
                        Message = message
                    }));
            }
        }
    }
}
