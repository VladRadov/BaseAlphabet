using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

using Alphabet.Model;
using Alphabet.View;
using Alphabet.Service;
using System.Diagnostics;

namespace Alphabet.Presenter
{
    internal class AuthorizationPresenter
    {
        private Authorization _authorization;

        private IAuthorizationView _authorizationView;

        public AuthorizationPresenter(Authorization authorization, IAuthorizationView authorizationView)
        {
            _authorization = authorization;
            _authorizationView = authorizationView;

            Subscribe();
        }

        private void Subscribe()
        {
            _authorizationView.AuthorizationEventHandler += OnAuthorization;
            _authorizationView.LoadEventHandler += OnLoadingForm;
            _authorizationView.LoadEventHandler += ChekingRunningApp;
            _authorizationView.LoadEventHandler += CheckingConnectionToDB;
        }

        public async void CheckingConnectionToDB()
        {
            await Task.Run(() =>
            {
                Color backColor = Color.FromArgb(192, 255, 192);
                try
                {
                    var checkConnection = new CheckConnection();
                    checkConnection.Execute();
                }
                catch (Exception exception)
                {
                    backColor = Color.FromArgb(255, 192, 192);
                }
                finally
                {
                    _authorizationView.SetColorChekingConnection(backColor);
                }
            });
        }

        private async void OnLoadingForm()
        {
            await Task.Run(() =>
            {
                Logger.Writer(new SQLWriteSystemLogger(
                    new AttributeSystemLog()
                    {
                        DateTimeCreate = DateTime.Now,
                        LevelMessage = "Info",
                        Message = "Загрузка основной формы"
                    }));

                var managerAD = new ManagerAD();
                var domains = managerAD.GetAllDomain();
                string[] domainsName = new string[managerAD.CountDomains() + 1];
                int count = 0;
                foreach (var domain in domains)
                {
                    domainsName[count] = domain.ToString();
                    ++count;
                }
                domainsName[domainsName.Count() - 1] = "Нет домена";
                _authorizationView.UpdateComBoxDomains(domainsName);
            });
        }

        private void OnAuthorization()
        {
            var userName = _authorizationView.Login;
            var password = _authorizationView.Password;
            try
            {
                _authorization.DomainName = _authorizationView.DomainNameView;

                if (_authorization.IsEnterLocalAdministrator(userName, password))
                    AuthorizationLocalAdmin();
                else
                    AuthorizationUserDB(userName, password);

            }
            catch (Exception exception)
            {
                Logger.Writer(new SQLWriteSystemLogger(
                    new AttributeSystemLog() 
                    { 
                        DateTimeCreate = DateTime.Now, 
                        LevelMessage = "Error", 
                        Message = "Ошибка авторизации пользователя " + userName + "! " + exception.ToString()
                    }));

                _authorizationView.ShowMessageBox(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AuthorizationLocalAdmin()
        {
            var UserSessionsPresenter = new UserSessionsPresenter(_authorizationView);
            UserSessionsPresenter.ChangeStateLocalAdminSession();
        }

        private void AuthorizationUserDB(string userName, string password)
        {
            string levelMessage = "Info";
            string message = string.Empty;
            try
            {
                Logger.Writer(new SQLWriteSystemLogger(
                    new AttributeSystemLog()
                    {
                        DateTimeCreate = DateTime.Now,
                        LevelMessage = "Info",
                        Message = "Попытка авторизации пользователем " + userName + "."
                    }));

                if (_authorization.IsEnterUserEqualWindowsUser(userName))
                {
                    if (_authorization.HasADEnterDataUser(userName, password))
                    {
                        var authorization = new AuthorizationToDatabase(userName);
                        authorization.Execute();

                        var UserSessionsPresenter = new UserSessionsPresenter(authorization, _authorizationView);
                        UserSessionsPresenter.ChangeStateUserSession();

                        message = "Пользователь " + userName + " успешно авторизован!";
                    }
                    else
                    {
                        levelMessage = "Error";
                        message = "Ошибка авторизации пользователя " + userName + "! " + "Проверьте корректность вводимых данных!";
                        _authorizationView.ShowMessageBox(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    levelMessage = "Error";
                    message = "Ошибка авторизации пользователя " + userName + "! " + "Вводимое имя не соответствует имени авторизованной учетной записи Windows!";
                    _authorizationView.ShowMessageBox(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exception)
            {
                levelMessage = "Error";
                message = "Ошибка авторизации пользователя " + userName + "! " + exception.ToString();
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

        private void ChekingRunningApp()
        {
            Process[] processList = Process.GetProcessesByName("Alphabet");
            if (processList.Length == 2)
            {
                _authorizationView.ShowMessageBox("Приложение уже запущено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                Application.Exit();
            }
        }
    }
}
