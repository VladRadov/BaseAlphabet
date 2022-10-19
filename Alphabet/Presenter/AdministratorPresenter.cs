using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Threading.Tasks;

using Alphabet.View;
using Alphabet.View.AdministratorViews;
using Alphabet.Model;
using Alphabet.Service;
using Alphabet.Data;

namespace Alphabet.Presenter
{
    internal class AdministratorPresenter
    {
        private IAdministratorView _administratorView;

        private IAddUserView _addUserView;

        private Administrator _administrator;

        public AdministratorPresenter(Administrator administrator, ISharedAdministratorView allUsersView)
        {
            _administrator = administrator;
            AllocationView(allUsersView);
            Subscribe();
        }

        private void AllocationView(IBaseVIew allUsersView)
        {
            if (allUsersView is IAdministratorView)
                _administratorView = (IAdministratorView)allUsersView;
            else if (allUsersView is IAddUserView)
                _addUserView = (IAddUserView)allUsersView;
        }

        private void Subscribe()
        {
            if (_administratorView != null)
            {
                _administratorView.ViewUsersEventHandler += OnViewAllUsers;
                _administratorView.SelectedUserEventHandler += OnSelectedUser;
                _administratorView.SelectAllUserGroupEventHandler += OnSelectAllUserGroup;
                _administratorView.EditUserEventHandler += EdetingUser;
                _administratorView.ViewLogTypesEventHandler += OnViewLogTypes;
                _administratorView.ViewLogsEventHandler += OnViewLogs;
                _administratorView.ViewUserActionsEventHandler += OnViewUserActions;

                _administratorView.ViewLoginsOfUsersActionsEventHandler += SelectedLoginsOfUsers;
                _administratorView.ViewUserActionTypesActionsEventHandler += SelectedUserActionTypes;

            }
            else if (_addUserView != null)
            {
                _addUserView.AddUserEventHandler += Adding;
                _addUserView.SelectAllUserGroupEventHandler += OnSelectAllUserGroup;
                _addUserView.ViewAllUsersFromadEventHandler += OnViewAllUserFromAD;
            }
        }

        private async void OnViewAllUserFromAD()
        {
            await Task.Run(() =>
            {
                try
                {
                    var managerAD = new ManagerAD();
                    var usersFromAD = managerAD.GetAllUSersFromAD();
                    string[] arrayUsers = new string[managerAD.CountUsersFromAD()];
                    int count = 0;
                    foreach (User userAD in usersFromAD)
                    {
                        arrayUsers[count] = userAD.Login;
                        ++count;
                    }

                    _addUserView.ViewAllUsersFromAD(arrayUsers);
                }
                catch (Exception exception)
                {
                    Logger.Writer(new SQLWriteSystemLogger(
                        new AttributeSystemLog()
                        {
                            DateTimeCreate = DateTime.Now,
                            LevelMessage = "Error",
                            Message = "Ошибка выполнения запроса на вывод всех пользователей AD! " + exception.ToString()
                        }));
                }
            });
        }

        private async void Adding()
        {
            string levelMessage = "Info";
            string message = string.Empty;

            await Task.Run(() =>
            {
                try
                {
                    if (_addUserView.ViewLogin.Length != 0 && _addUserView.ViewUserGroup.Length != 0)
                    {
                        var addUser = new AddUser(_addUserView.ViewLogin, _addUserView.ViewUserGroup);
                        addUser.Execute();

                        var nameColumn = addUser.GetNameColumn(0);
                        if (nameColumn == "Error")
                        {
                            var messageSql = addUser.ParseTableResult(0, 0);
                            message = messageSql;
                            _addUserView.ShowMessageBox(messageSql, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            message = "Пользователь успешно добавлен! " + addUser.ParseTableResult(0, 0);
                            _addUserView.ShowMessageBox("Пользователь успешно добавлен!", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        levelMessage = "Info";
                    }
                    else
                        _addUserView.ShowMessageBox("Заполните все поля!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception exception)
                {
                    levelMessage = "Error";
                    message = "Ошибка выполнения процедуры добавления " + _administratorView.ViewLogin + " пользователя! " + exception.ToString();
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
            });
        }

        private async void EdetingUser(ListView listView)
        {
            string levelMessage = "Info";
            string message = string.Empty;
            await Task.Run(() =>
            {
                try
                {
                    var edetingUser = new EditUser(_administratorView.ViewLogin, _administratorView.ViewIsDeleteed, _administratorView.ViewUserGroup);
                    edetingUser.Execute();

                    levelMessage = "Info";
                    message = edetingUser.ParseTableResult(0, 0);
                    _administratorView.ShowMessageBox(message, "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnViewAllUsers(listView);
                }
                catch (Exception exception)
                {
                    levelMessage = "Error";
                    message = "Ошибка выполнения процедуры изменения данных " + _administratorView.ViewLogin + " пользователя! " + exception.ToString();
                    _administratorView.ShowMessageBox(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            });
        }

        private async void OnSelectAllUserGroup(ISharedAdministratorView allUsersView)
        {
            await Task.Run(() =>
                {
                    try
                    {
                        var allUserGroup = new SelectAllUserGroup();
                        allUserGroup.Execute();

                        var count = allUserGroup.CountTableResultRows();
                        string[] userGroups = new string[count];
                        for (int i = 0; i < count; i++)
                        {
                            userGroups[i] = allUserGroup.ParseTableResult(i, NameColumns.UserGroup);
                        }

                        allUsersView.ViewAllUserGroup(userGroups);
                    }
                    catch (Exception exception)
                    {
                        Logger.Writer(new SQLWriteSystemLogger(
                            new AttributeSystemLog()
                            {
                                DateTimeCreate = DateTime.Now,
                                LevelMessage = "Error",
                                Message = "Ошибка выполнения процедуры просмотра всех групп прав пользователей! " + exception.ToString()
                            }));
                    }
                });
        }

        private async void OnViewAllUsers(ListView listView)
        {
            await Task.Run(() =>
            {
                string levelMessage = "Info";
                string message = string.Empty;
                try
                {
                    var allUsers = new SelectAllUsers();
                    allUsers.Execute();

                    var count = allUsers.CountTableResultRows();
                    ListViewItem[] rows = new ListViewItem[count];
                    _administrator.ClearAllUsers();
                    for (int i = 0; i < count; i++)
                    {
                        var userId = int.Parse(allUsers.ParseTableResult(i, NameColumns.UserID));
                        var fio = allUsers.ParseTableResult(i, NameColumns.FIO);
                        var login = allUsers.ParseTableResult(i, NameColumns.Login);
                        var isDeleted = allUsers.ParseTableResult(i, NameColumns.IsDeleted) == "1" ? true : false;
                        var userGroupName = allUsers.ParseTableResult(i, NameColumns.UserGroup);

                        var permissionARMs = new SelectPermissionARMs(login);
                        permissionARMs.Execute();


                        List<ARM> arms = new List<ARM>();
                        foreach (DataRow arm in permissionARMs.ParseTableResult())
                            arms.Add(ARMManager.EnterARM(arm.ItemArray[0].ToString()));

                        _administrator.AddUser(new User()
                        {
                            UserID = userId,
                            FIO = fio,
                            Login = login,
                            IsDeleted = isDeleted,
                            UserGroup = ManagerUsersGroup.FindUsersGroup(userGroupName, arms)
                        });

                        rows[i] = new ListViewItem(new string[] { login, fio, isDeleted == true ? "Удален" : "Не удален", userGroupName });
                    }

                    _administratorView.UpdateListView(listView, new ColumnHeader[]
                {
                new ColumnHeader(NameColumns.Login){ Text = NameColumns.Login},
                new ColumnHeader(NameColumns.FIO){ Text = NameColumns.FIO},
                new ColumnHeader(NameColumns.IsDeleted){ Text = NameColumns.IsDeleted},
                new ColumnHeader(NameColumns.UserGroup) { Text = NameColumns.UserGroup}
                }, rows);

                    levelMessage = "Info";
                    message = "Успешное завершение выполнения процедуры просмотра всех пользователей.";
                }
                catch (Exception exception)
                {
                    levelMessage = "Error";
                    message = "Ошибка выполнения процедуры просмотра всех пользователей! " + exception.ToString();
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
            });
        }

        private void OnSelectedUser(string login)
        {
            var selectedUser = _administrator.FindUser(login);
            _administratorView.ViewFIO = selectedUser.FIO;
            _administratorView.ViewLogin = selectedUser.Login;
            _administratorView.ViewUserGroup = selectedUser.UserGroup.Name;
            _administratorView.ViewIsDeleteed = selectedUser.IsDeleted;

            _administratorView.ViewDataSelectedUser();
        }

        private void OnViewLogs(ListView listView, DateTime start, DateTime finish, string logType, string description)
        {
            OnViewItemsListView(
                listView,
                new ViewLogs(start, finish, logType, description),
                @"Успешное завершение выполнения процедуры просмотра журнала системных операций. Параметры поиска: c " + 
                start + " по " + finish + ", тип операция - " + logType + ", описание - " + description + ".",
                "Ошибка выполнения процедуры просмотра журнала системных операций! "
            );
        }

        private void OnViewUserActions(ListView listView, DateTime start, DateTime finish, string loginUser, string nameUserActionType)
        {
            OnViewItemsListView(
                listView,
                new ViewUserActions(start, finish, loginUser, nameUserActionType),
                @"Успешное завершение выполнения процедуры просмотра журнала операций пользователей. Параметры поиска: c " + 
                start + " по " + finish + ", пользователь - " + loginUser + ", тип операции - " + nameUserActionType + ".",
                "Ошибка выполнения процедуры просмотра журнала операций пользователей! "
                );
        }

        private async void OnViewItemsListView(ListView listView, BaseQuery baseQuery, string messageSuccess, string messageError)
        {
            await Task.Run(() =>
            {
                string levelMessage = "Info";
                string message = string.Empty;
                try
                {
                    baseQuery.Execute();

                    var countRows = baseQuery.CountTableResultRows();
                    var countColumns = baseQuery.CountTableResultColumns();
                    ListViewItem[] rows = new ListViewItem[countRows];
                    ColumnHeader[] columns = new ColumnHeader[countColumns];
                    for (int i = 0; i < countColumns; i++)
                    {
                        var nameColumn = baseQuery.GetNameColumn(i);
                        columns[i] = new ColumnHeader() { Name = nameColumn, Text = nameColumn };
                    }

                    for (int i = 0; i < countRows; i++)
                    {
                        for (int j = 0; j < countColumns; j++)
                        {
                            var item = baseQuery.ParseTableResult(i, j);
                            if (j == 0)
                                rows[i] = new ListViewItem(item);
                            else
                                rows[i].SubItems.Add(item);
                        }
                    }

                    _administratorView.UpdateListView(listView, columns, rows);

                    levelMessage = "Info";
                    message = messageSuccess;
                }
                catch (Exception exception)
                {
                    levelMessage = "Error";
                    message = messageError + exception.ToString();
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
            });
        }

        private void OnViewLogTypes(ComboBox cBox)
        {
            OnViewItemsComboBox(
                new SelectLogTypes(),
                NameColumns.LogTypes,
                "Ошибка выполнения процедуры вывода всех уровней события журнала операций! ",
                cBox);
        }

        private void SelectedLoginsOfUsers(ComboBox cBox)
        {
            OnViewItemsComboBox(
                new SelectAllUsers(),
                NameColumns.Login,
                "Ошибка выполнения процедуры отображения логинов всех пользователей! ",
                cBox);
        }

        private void SelectedUserActionTypes(ComboBox cBox)
        {
            OnViewItemsComboBox(
                new SelectUserActionTypes(), 
                NameColumns.UserActionTypes, 
                "Ошибка выполнения процедуры отображения всех типов событий! ",
                cBox);
        }


        private async void OnViewItemsComboBox(BaseQuery baseQuery, string column, string messageError, ComboBox cBox)
        {
            await Task.Run(() =>
            {
                try
                {
                    baseQuery.Execute();

                    var count = baseQuery.CountTableResultRows();
                    string[] rows = new string[count];
                    for (int i = 0; i < count; i++)
                    {
                        rows[i] = baseQuery.ParseTableResult(i, column);
                    }

                    _administratorView.UpdateComboBox(cBox, rows);
                }
                catch (Exception exception)
                {
                    Logger.Writer(new SQLWriteSystemLogger(
                        new AttributeSystemLog()
                        {
                            DateTimeCreate = DateTime.Now,
                            LevelMessage = "Error",
                            Message = messageError + exception.ToString()
                        }));
                }
            });
        }
    }
}
