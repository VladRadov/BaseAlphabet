using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Alphabet.View.PersonsOperations;
using Alphabet.Service;
using Alphabet.Model;
using Alphabet.View;

namespace Alphabet.Presenter
{
    internal class PersonsOpearationsPresenter
    {
        private Person _person;

        IPersonsAddOrDeleteView _personsAddOrDeleteView;

        IPersonsSelectView _personsSelectView;

        private int _numberTelegram;

        public PersonsOpearationsPresenter(Person person, IPersonsOperationsView personsOpearationsView)
        {
            _person = person;
            SelectionView(personsOpearationsView);
        }

        private void SelectionView(IPersonsOperationsView personsOpearationsView)
        {
            if (personsOpearationsView is IPersonsAddOrDeleteView)
            {
                _personsAddOrDeleteView = (IPersonsAddOrDeleteView)personsOpearationsView;
                SubscribeForPersonsAddOrDeleteView();
            }
            else if (personsOpearationsView is IPersonsSelectView)
            {
                _personsSelectView = (IPersonsSelectView)personsOpearationsView;
                SubscribeForPersonsSelectView();
            }
        }

        private void SubscribeForPersonsAddOrDeleteView()
        {
            _personsAddOrDeleteView.InsertTelegramEventHandler += InsertingNumberTelegram;
            _personsAddOrDeleteView.OperationsOnPersonsEventHandler += OperationsOnPersons;
            _personsAddOrDeleteView.DecisionBakingOnPersonEventHandler += OnDecisionBakingOnPerson;
            _personsAddOrDeleteView.HandEditNoFindedPersonsEventHandler += HandEditingNoFindedPersons;
            _personsAddOrDeleteView.GetPersonDTEventHandler += OnGetPersonDT;
            _personsAddOrDeleteView.ChangeBorderRoutingEventHandler += OnChangeBorderRouting;
        }

        private void SubscribeForPersonsSelectView()
        {
            _personsSelectView.LoadDataOfFiltersSearchEventHandler += LoadingDataOfFiltersSearch;
            _personsSelectView.FindPersonsEventHandler += FindingPersons;
        }

        private void InsertingNumberTelegram(string numberTelegram, DateTime dateofSigning, string description)
        {
            var insertTelegram = new InsertTelegram(numberTelegram, dateofSigning, description);
            insertTelegram.Execute();

            _numberTelegram = int.Parse(insertTelegram.ParseTableResult(0, 0));
        }

        private async void OperationsOnPersons(int borderRouting, int typeOperation, string dateSubmission)
        {
            string levelMessage = "Info";
            string message = string.Empty;
            await Task.Run(() =>
            {
                try
                {
                    if (_numberTelegram < 0)
                    {
                        levelMessage = "Info";
                        message = "Введите номер телеграммы!";
                        _personsAddOrDeleteView.ShowMessageBox(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (Person.List.Count == 0)
                    {
                        levelMessage = "Info";
                        message = "Загрузите список ОУ!";
                        _personsAddOrDeleteView.ShowMessageBox(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        var warn = string.Format("№ телеграммы - {0}. \nНаправление - {1}. \nДата подписания - {2}.", _numberTelegram.ToString(), borderRouting == 0 ? "Въезд" : "Выезд", dateSubmission);
                        if (_personsAddOrDeleteView.ShowMessageBox(warn, "Проверка", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _personsAddOrDeleteView.SetEnableControls(false);
                            var list = Person.List.Where(x => x.Route == borderRouting && x.Type == typeOperation).ToList();
                            ((IProgressBarView)_personsAddOrDeleteView).SetMaximum(list.Count());
                            if (typeOperation == 2)
                                RegistrationPersons(list, ref levelMessage, ref message);
                            else if (typeOperation == 1)
                                DeregistrationPersons(list, ref levelMessage, ref message);

                            _personsAddOrDeleteView.SetEnableControls(true);
                            _personsAddOrDeleteView.CreateTableResult(Person.List.Where(x => x.Route == borderRouting && x.Type == typeOperation).ToList());
                            _personsAddOrDeleteView.ShowMessageBox(message, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception exception)
                {
                    Connection.Instance.CloseConnection();
                    levelMessage = "Error";
                    message = "Ошибка выполнения операции над персоной! " + exception.ToString();
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

        private void RegistrationPersons(List<Person> persons, ref string levelMessage, ref string message)
        {
            Logger.Writer(new SQLWriteSystemLogger(
                new AttributeSystemLog()
                {
                    DateTimeCreate = DateTime.Now,
                    LevelMessage = "Info",
                    Message = "Начало операции постановки на учёт."
                }));
            try
            {
                int count = 0;
                ((IProgressBarView)_personsAddOrDeleteView).SetMaximum(persons.Count);
                foreach (Person item in persons)
                {
                    var insertPerson = new InsertPerson(item, _numberTelegram);
                    insertPerson.Execute();
                    var flagInserted = insertPerson.ParseTableResult(0, 0);
                    if (flagInserted != "")
                    {
                        Person.List.Remove(item);
                        ++count;
                        Logger.Writer(new SQLWriteUserActionLogger(
                new AttributeUserActionLog()
                {
                    DateTimeCreate = DateTime.Now,
                    IdPerson = int.Parse(flagInserted),
                    LoginUser = UserSessions.Instance.User.Login,
                    NameUserActionType = "Постановка"
                }));
                    }
                    ((IProgressBarView)_personsAddOrDeleteView).SetValue(count);
                }
                levelMessage = "Info";
                message = "Завершение операции постановки на учёт. Количество обработанных записей - " + count.ToString();
            }
            catch (Exception exception)
            {
                levelMessage = "Error";
                message = "Ошибка операции постановки на учёт! " + exception.ToString();
            }
        }

        private void DeregistrationPersons(List<Person> persons, ref string levelMessage, ref string message)
        {
            Logger.Writer(new SQLWriteSystemLogger(
                new AttributeSystemLog()
                {
                    DateTimeCreate = DateTime.Now,
                    LevelMessage = "Info",
                    Message = "Начало операции снятия с учёта."
                }));
            try
            {
                ((IProgressBarView)_personsAddOrDeleteView).SetMaximum(persons.Count);
                foreach (Person item in persons)
                {
                    var comparePersons = new ComparePersons(item);
                    comparePersons.Execute();

                    item.DT = comparePersons.GetTableResult();
                    if (item.DT.Rows.Count == 0)
                        item.IsDeleted = false;
                    else if (item.DT.Rows.Count > 1)
                        item.IsMulty = true;
                    else
                    {
                        item.IsDeleted = true;
                        var changeStatePerson = new ChangeStatePerson(Convert.ToInt64(item.DT.Rows[0].ItemArray[0]), _numberTelegram);
                        changeStatePerson.Execute();
                        Logger.Writer(new SQLWriteUserActionLogger(
                new AttributeUserActionLog()
                {
                    DateTimeCreate = DateTime.Now, 
                    IdPerson = item.Id,
                    LoginUser = UserSessions.Instance.User.Login,
                    NameUserActionType = "Снятие"
                }));
                    }
                    ((IProgressBarView)_personsAddOrDeleteView).SetValue(1);
                }


                foreach (var item in persons.Where(x => x.IsDeleted))
                {
                    Person.List.Remove(item);
                }
                persons.RemoveAll(x => x.IsDeleted);
                levelMessage = "Info";
                var countPersonsNoDelete = persons.Where(x => !x.IsDeleted).Count();
                var countPersons = persons.Count();
                var res = string.Format("Количество снятых записей - {0}. Ожидают принятия решения - {1}.", countPersons - countPersonsNoDelete, countPersonsNoDelete);
                message = "Завершение операции снятия с учёта. " + res;
            }
            catch (Exception exception)
            {
                levelMessage = "Error";
                message = "Ошибка операции снятия с учёта! " + exception.ToString();
            }
        }

        private async void LoadingDataOfFiltersSearch()
        {
            string levelMessage = "Info";
            string message = string.Empty;
            await Task.Run(() =>
            {
                try
                {
                    var selectUsers = new SelectUsersLogin();
                    selectUsers.Execute();
                    _personsSelectView.ViewUsers = selectUsers.GetArray();

                    var selectMarks = new SelectMarks();
                    selectMarks.Execute();
                    _personsSelectView.ViewMarks = selectMarks.GetArray();

                    var selectCountries = new SelectCountries();
                    selectCountries.Execute();
                    _personsSelectView.ViewCountries = selectCountries.GetArray();

                    _personsSelectView.UpdateFiltersControls();
                    levelMessage = "Debug";
                    message = "Данные пользователей, индексов и стран для фильтров успешно загружены.";
                }
                catch (Exception exception)
                {
                    levelMessage = "Error";
                    message = "Ошибка загрузки данных для фильтров из БД! " + exception.ToString();
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

        private async void FindingPersons(string filter)
        {
            string levelMessage = "Info";
            string message = string.Empty;
            await Task.Run(() =>
            {
                try
                {
                    var findPersons = new FindPersons(filter);
                    findPersons.Execute();

                    _personsSelectView.UpdateFindedListPersons(findPersons.GetTableResult());
                    levelMessage = "Info";
                    message = "Поиск лица выполнен успешно! Параметры поиска: " + filter;
                }
                catch (Exception exception)
                {
                    levelMessage = "Error";
                    message = "Ошибка при выполнении поиска лица с параметрами: " + filter + "! " + exception.ToString();
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

        private async void OnDecisionBakingOnPerson(long value)
        {
            string levelMessage = "Info";
            string message = string.Empty;
            await Task.Run(() =>
            {
                try
                {
                    var changeStatePerson = new ChangeStatePerson(value, _numberTelegram);
                    changeStatePerson.Execute();
                    Person.List.Remove(Person.List.First(x => x.Id == value));
                    _personsAddOrDeleteView.UpdateTable();
                    levelMessage = "Info";
                    message = "Принятие решения по дублированным записям!";
                }
                catch (Exception exception)
                {
                    levelMessage = "Error";
                    message = "Ошибка принятие решения по дублированным записям! " + exception.ToString();
                }
                finally
                {
                    _personsAddOrDeleteView.SetEnableControls(true);
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

        private async void HandEditingNoFindedPersons(int value)
        {
            string levelMessage = "Info";
            string message = string.Empty;
            await Task.Run(() =>
            {
                try
                {
                    Person.List.Remove(Person.List.First(x => x.Id == value));
                    _personsAddOrDeleteView.UpdateTable();
                    levelMessage = "Info";
                    message = "Ручное редактирование списка не найденных в БД.";
                }
                catch (Exception exception)
                {
                    levelMessage = "Error";
                    message = "Ошибка ручного редактирования списка не найденных лиц в БД! " + exception.ToString();
                }
                finally
                {
                    _personsAddOrDeleteView.SetEnableControls();
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

        private async void OnGetPersonDT(int value)
        {
            string levelMessage = "Info";
            string message = string.Empty;
            await Task.Run(() =>
            {
                try
                {
                    var dataTable = Person.List.First(x => x.Id == value).DT;
                    _personsAddOrDeleteView.UpdatePersonDT(dataTable);
                    levelMessage = "Info";
                    //Выполнено что
                    message = "Выполнено ... ";
                }
                catch (Exception exception)
                {
                    levelMessage = "Error";
                    //Ошибка чего
                    message = "Ошибка ...! " + exception.ToString();
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

        private async void OnChangeBorderRouting(int borderRouting, int typeOperation)
        {
            string levelMessage = "Info";
            string message = string.Empty;
            await Task.Run(() =>
            {
                try
                {
                    var list = Person.List.Where(x => x.Route == borderRouting && x.Type == typeOperation).ToList();
                    _personsAddOrDeleteView.CreateTableResult(list);
                    levelMessage = "Info";
                    message = "Смена направления с " + (borderRouting != 0 ? "Въезд" : "Выезд") + " на " + (borderRouting == 0 ? "Въезд" : "Выезд") + ".";
                }
                catch (Exception exception)
                {
                    levelMessage = "Error";
                    message = "Ошибка при смене направления! " + exception.ToString();
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
    }
}
