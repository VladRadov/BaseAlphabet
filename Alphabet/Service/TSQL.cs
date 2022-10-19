using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Alphabet.Model;

namespace Alphabet.Service
{
    internal class Connection
    {
        private SqlConnection _connection;

        private Connection()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = @"Server = " + StringConnection.Server + "; Initial catalog = AlphabetDB; Connection Timeout = " +
                            StringConnection.ConnectionTimeout.ToString() + "; Integrated Security = True; Pooling = true; MultipleActiveResultSets=true";
        }

        private static Connection _instance;

        public static Connection Instance => _instance ?? (_instance = new Connection());

        public SqlConnection GetConnection() 
        {
           
            return _connection;
        }
    }

    class StringConnection
    {
        public static string Server { get; set; }

        public static int ConnectionTimeout { get; set; }
    }

    class BaseQuery
    {
        protected DataTable _tableResult { get; set; }

        protected SqlCommand _sqlCommand { get; set; }

        public virtual void Execute()
        {
            var connecting = Connection.Instance.GetConnection();
            try
            {
                _tableResult = new DataTable();
                _sqlCommand = connecting.CreateCommand();

                CreateSqlCommand();
                using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        _tableResult.Columns.Add(reader.GetName(i).ToString());
                    while (reader.Read())
                    {
                        string[] subItems = new string[reader.FieldCount];

                        for (int i = 0; i < reader.FieldCount; i++)
                            subItems[i] = reader.GetValue(i).ToString();

                        _tableResult.Rows.Add(subItems[0]);
                        _tableResult.Rows[_tableResult.Rows.Count - 1].ItemArray = subItems;
                    }
                } 
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        protected virtual void CreateSqlCommand()
        {

        }

        public DataTable GetTableResult()
        {
            return _tableResult;
        }

        public string ParseTableResult(int idRow, string nameColumn)
        {
            return _tableResult.Rows[idRow].ItemArray.GetValue(_tableResult.Columns[nameColumn].Ordinal).ToString();
        }

        public string ParseTableResult(int idRow, int idColumn)
        {
            return _tableResult.Rows[idRow].ItemArray.GetValue(_tableResult.Columns[idColumn].Ordinal).ToString();
        }

        public IEnumerable ParseTableResult()
        {
            return _tableResult.Rows;
        }

        public string[] GetArray()
        {
            string[] result = new string[CountTableResultRows()];
            int count = 0;
            foreach (DataRow row in _tableResult.Rows)
            {
                result[count] = row.ItemArray[0].ToString();
                ++count;
            }

            return result;
        }

        public int CountTableResultRows()
        {
            return _tableResult.Rows.Count;
        }

        public int CountTableResultColumns()
        {
            return _tableResult.Columns.Count;
        }

        public string GetNameColumn(int idColumn)
        {
            return _tableResult.Columns[idColumn].ColumnName;
        }
    }

    class CheckConnection : BaseQuery
    {
        public override void Execute()
        {
            var connecting = Connection.Instance.GetConnection();
            //connecting.Open();
        }
    }

    class AuthorizationToDatabase : BaseQuery
    {
        private string _login;

        public AuthorizationToDatabase(String login)
        {
            _login = login;
        }
        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "AuthorizationUser";
            _sqlCommand.Parameters.Add("@Login", SqlDbType.VarChar, 32);
            _sqlCommand.Parameters[0].Value = _login;
        }
    }

    class SelectPermissionARMs : BaseQuery
    {
        private string _login;

        public SelectPermissionARMs(String login)
        {
            _login = login;
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "SelectPermissionARMs";
            _sqlCommand.Parameters.Add("@Login", SqlDbType.VarChar, 32);
            _sqlCommand.Parameters[0].Value = _login;
        }
    }

    class SelectAllUsers : BaseQuery
    {
        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "SelectAllUsers";
        }
    }

    class SelectAllUserGroup : BaseQuery
    {
        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "SelectAllUserGroup";
        }
    }

    class WorkingWithUser : BaseQuery
    {
        protected string _login { get; set; }

        protected bool _isDeleted { get; set; }

        protected string _nameUserGroup { get; set; }
    }

    class EditUser : WorkingWithUser
    {
        public EditUser(string login, bool isDeleted, string nameUserGroup)
        {
            _login = login;
            _isDeleted = isDeleted;
            _nameUserGroup = nameUserGroup;
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "EditUser";
            _sqlCommand.Parameters.Add("@Login", SqlDbType.VarChar, 32);
            _sqlCommand.Parameters[0].Value = _login;
            _sqlCommand.Parameters.Add("@IsDeleted", SqlDbType.Int);
            _sqlCommand.Parameters[1].Value = _isDeleted;
            _sqlCommand.Parameters.Add("@NameUserGroup", SqlDbType.VarChar, 128);
            _sqlCommand.Parameters[2].Value = _nameUserGroup;
        }
    }

    class AddUser : WorkingWithUser
    {
        public AddUser(string login, string nameUserGroup)
        {
            _login = login;
            _nameUserGroup = nameUserGroup;
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "AddUser";
            _sqlCommand.Parameters.Add("@FIO", SqlDbType.VarChar, 128);
            _sqlCommand.Parameters[0].Value = _login;
            _sqlCommand.Parameters.Add("@Login", SqlDbType.VarChar, 32);
            _sqlCommand.Parameters[1].Value = _login;
            _sqlCommand.Parameters.Add("@NameUserGroup", SqlDbType.VarChar, 128);
            _sqlCommand.Parameters[2].Value = _nameUserGroup;
        }
    }

    class AddRecordToLog : BaseQuery
    {
        private DateTime _dateTimeCreate;

        private string _description;

        private string _nameLogType;

        public AddRecordToLog(DateTime dateTimeCreate, string nameLogType, string description)
        {
            _dateTimeCreate = dateTimeCreate;
            _nameLogType = nameLogType;
            _description = description;
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "AddRecordToLog";
            _sqlCommand.Parameters.Add("@Datetime", SqlDbType.VarChar, 32);
            _sqlCommand.Parameters[0].Value = _dateTimeCreate.ToString("yyyyMMdd HH:mm:ss");
            _sqlCommand.Parameters.Add("@NameLogType", SqlDbType.VarChar, 128);
            _sqlCommand.Parameters[1].Value = _nameLogType;
            _sqlCommand.Parameters.Add("@Description", SqlDbType.VarChar);
            _sqlCommand.Parameters[2].Value = _description;
        }
    }

    class SelectLogTypes : BaseQuery
    {
        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "SelectLogTypes";
        }
    }

    class ViewLogs : BaseQuery
    {
        private string _datetimeStart;

        private string _datetimeFinish;

        private string _nameLogType;

        private string _description;

        public ViewLogs(DateTime dateTimeCreate, DateTime datetimeFinish, string nameLogType, string description)
        {
            _datetimeStart = dateTimeCreate.ToString("yyyyMMdd HH:mm:ss");
            _datetimeFinish = datetimeFinish.ToString("yyyyMMdd HH:mm:ss");
            _nameLogType = nameLogType;
            _description = description;
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "ViewLogs";
            _sqlCommand.Parameters.Add("@DatetimeStart", SqlDbType.VarChar, 32);
            _sqlCommand.Parameters[0].Value = _datetimeStart;
            _sqlCommand.Parameters.Add("@DatetimeFinish", SqlDbType.VarChar, 32);
            _sqlCommand.Parameters[1].Value = _datetimeFinish;
            _sqlCommand.Parameters.Add("@NameLogType", SqlDbType.VarChar);
            if (string.IsNullOrWhiteSpace(_nameLogType))
                _sqlCommand.Parameters[2].Value = DBNull.Value;
            else
                _sqlCommand.Parameters[2].Value = _nameLogType;
            _sqlCommand.Parameters.Add("@Description", SqlDbType.VarChar);
            if (string.IsNullOrWhiteSpace(_description))
                _sqlCommand.Parameters[3].Value = DBNull.Value;
            else
                _sqlCommand.Parameters[3].Value = _description;
        }
    }

    class InsertRecordUserAction : BaseQuery
    {
        private DateTime _dateTimeCreate;

        private string _loginUser;

        private string _nameUserActionType;

        private int _idPerson;

        public InsertRecordUserAction(DateTime dateTimeCreate, string loginUser, string nameUserActionType, int idPerson)
        {
            _dateTimeCreate = dateTimeCreate;
            _loginUser = loginUser;
            _nameUserActionType = nameUserActionType;
            _idPerson = idPerson;
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "InsertRecordUserAction";
            _sqlCommand.Parameters.Add("@Datetime", SqlDbType.VarChar, 32);
            _sqlCommand.Parameters[0].Value = _dateTimeCreate.ToString("yyyyMMdd HH:mm:ss");
            _sqlCommand.Parameters.Add("@LoginUser", SqlDbType.VarChar, 32);
            _sqlCommand.Parameters[1].Value = _loginUser;
            _sqlCommand.Parameters.Add("@NameUserActionType", SqlDbType.VarChar, 128);
            _sqlCommand.Parameters[2].Value = _nameUserActionType;
            _sqlCommand.Parameters.Add("@IdPerson", SqlDbType.Int);
            _sqlCommand.Parameters[3].Value = _idPerson;
        }
    }

    class ViewUserActions : BaseQuery
    {
        private string _datetimeStart;

        private string _datetimeFinish;

        private string _loginUser;

        private string _nameUserActionType;

        public ViewUserActions(DateTime dateTimeCreate, DateTime datetimeFinish, string loginUser, string nameUserActionType)
        {
            _datetimeStart = dateTimeCreate.ToString("yyyyMMdd HH:mm:ss");
            _datetimeFinish = datetimeFinish.ToString("yyyyMMdd HH:mm:ss");
            _loginUser = loginUser;
            _nameUserActionType = nameUserActionType;
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "ViewUserActions";
            _sqlCommand.Parameters.Add("@DatetimeStart", SqlDbType.VarChar, 32);
            _sqlCommand.Parameters[0].Value = _datetimeStart;
            _sqlCommand.Parameters.Add("@DatetimeFinish", SqlDbType.VarChar, 32);
            _sqlCommand.Parameters[1].Value = _datetimeFinish;
            _sqlCommand.Parameters.Add("@LoginUser", SqlDbType.VarChar, 32);
            if (string.IsNullOrWhiteSpace(_loginUser))
                _sqlCommand.Parameters[2].Value = DBNull.Value;
            else
                _sqlCommand.Parameters[2].Value = _loginUser;
            _sqlCommand.Parameters.Add("@NameUserActionType", SqlDbType.VarChar, 128);
            if (string.IsNullOrWhiteSpace(_nameUserActionType))
                _sqlCommand.Parameters[3].Value = DBNull.Value;
            else
                _sqlCommand.Parameters[3].Value = _nameUserActionType;
        }
    }

    class SelectUserActionTypes : BaseQuery
    {
        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "SelectUserActionTypes";
        }
    }

    class ResetUserSession : BaseQuery
    {
        private string _login;

        public ResetUserSession(string login)
        {
            _login = login;
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "ResetUserSession";
            _sqlCommand.Parameters.Add("@Login", SqlDbType.VarChar, 32);
            _sqlCommand.Parameters[0].Value = _login;
        }
    }

    class InsertTelegram : BaseQuery
    {
        private string _number;

        private DateTime _dateofSigning;

        private string _description;

        public InsertTelegram(string number, DateTime dateofSigning, string description)
        {
            _number = number;
            _dateofSigning = dateofSigning;
            _description = description;
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "InsertTelegram";
            _sqlCommand.Parameters.AddWithValue("@Number", _number);
            _sqlCommand.Parameters.AddWithValue("@DateofSigning", _dateofSigning.ToString("yyyyMMdd"));
            _sqlCommand.Parameters.AddWithValue("@Description", DBNull.Value);
        }
    }

    class InsertPerson : BaseQuery
    {
        private Person _person;

        private int _idTelegram;

        public InsertPerson(Person person, int idTelegram)
        {
            _person = person;
            _idTelegram = idTelegram;
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandTimeout = 86400;
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "InsertPerson";
            _sqlCommand.Parameters.AddWithValue("@IdTelegram", _idTelegram);
            _sqlCommand.Parameters.AddWithValue("@FIO", _person.FIO);
            _sqlCommand.Parameters.AddWithValue("@DateOfBirth", _person.DateOfBirth == DateTime.MinValue ? (object)DBNull.Value : _person.DateOfBirth.ToString("yyyyMMdd"));
            _sqlCommand.Parameters.AddWithValue("@DateExpire", _person.DateExpire == DateTime.MinValue ? (object)DBNull.Value : _person.DateExpire.ToString("yyyyMMdd"));
            _sqlCommand.Parameters.AddWithValue("@Sex", string.IsNullOrWhiteSpace(_person.Sex) ? (object)DBNull.Value : _person.Sex);
            _sqlCommand.Parameters.AddWithValue("@Task", _person.Task);
            _sqlCommand.Parameters.AddWithValue("@TaskKey", _person.TaskKey);
            _sqlCommand.Parameters.AddWithValue("@Country", string.IsNullOrWhiteSpace(_person.Country) ? (object)DBNull.Value : _person.Country);
            _sqlCommand.Parameters.AddWithValue("@Mark", _person.Index);
            _sqlCommand.Parameters.AddWithValue("@Route", _person.Route);
            _sqlCommand.Parameters.AddWithValue("@Additionally", _person.Additionally == null ? (object)DBNull.Value : _person.Additionally);
            _sqlCommand.Parameters.AddWithValue("@PlaceOfBirth", _person.PlaceOfBirth == null ? (object)DBNull.Value : _person.PlaceOfBirth);

        }
    }

    class ComparePersons : BaseQuery
    {
        private Person _person;

        public ComparePersons(Person person)
        {
            _person = person;
        }
        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandTimeout = 86400;
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "Compare";
            _sqlCommand.Parameters.AddWithValue("@FIO", _person.FIO);
            _sqlCommand.Parameters.AddWithValue("@DateOfBirth", _person.DateOfBirth.ToString("yyyyMMdd"));
            _sqlCommand.Parameters.AddWithValue("@DateExpire", _person.DateExpire.ToString("yyyyMMdd"));
            _sqlCommand.Parameters.AddWithValue("@Route", _person.Route);
            _sqlCommand.Parameters.AddWithValue("@Mark", _person.Index);
            _sqlCommand.Parameters.AddWithValue("@TaskKey", _person.TaskKey);
        }
    }

    class ChangeStatePerson : BaseQuery
    {
        private long _idPerson;

        private int _idTelegram;

        public ChangeStatePerson(long idPerson, int idTelegram)
        {
            _idPerson = idPerson;
            _idTelegram = idTelegram;
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandTimeout = 86400;
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "Change";
            _sqlCommand.Parameters.AddWithValue("@IdPerson", _idPerson);
            _sqlCommand.Parameters.AddWithValue("@IdTelegram", _idTelegram);
        }
    }

    class SelectMarks : BaseQuery
    {
        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "SelectMarks";
        }
    }

    class SelectCountries : BaseQuery
    {
        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "SelectCountries";
        }
    }

    class SelectUsersLogin : BaseQuery
    {
        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "SelectUsersLogin";
        }
    }

    class FindPersons : BaseQuery
    {
        private string _filters;

        public FindPersons(string filters)
        {
            _filters = filters;
        }

        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandTimeout = 86400;
            _sqlCommand.CommandType = CommandType.Text;
            _sqlCommand.CommandText = @"
select p.Id, p.IsDeleted [Снят], p.FIO [ФИО], p.DateOfBirth [Дата рождения], m.Name [Отметка], t.Number [Номер телеграммы], t.DateOfSigning [Дата подписания],
p.DateExpire [Срок контроля], p.Task [Задание], us.FIO [Пользователь] from Person p
inner join TelegramPerson pt on pt.IdPerson=p.Id
inner join Telegram t on t.Id=pt.IdTelegram  
inner join [Mark] m on m.Id=p.IdMark 
inner join UserAction u on u.IdPerson = p.Id
inner join [User] us on us.Id=u.IdUser " + (string.IsNullOrWhiteSpace(_filters) ? "" : _filters.Trim().Insert(0, "where").Replace("whereand", "where")) +
@" group by  p.Id, p.IsDeleted  , p.FIO  , p.DateOfBirth , m.Name , t.Number , t.DateOfSigning ,
p.DateExpire  , p.Task , us.FIO ";
        }
    }

    class SelectAllArms : BaseQuery
    {
        public override void Execute()
        {
            base.Execute();
        }

        protected override void CreateSqlCommand()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "SelectAllArms";
        }
    }
}
