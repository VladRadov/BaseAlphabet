using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using EditingRegistrationApp.Properties;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditingRegistrationApp
{
    class DB
    {
        private static SqlConnection _con;
        public static string ExceptionText { get; set; }

        public static Task<bool> Open()
        {
            return Task.Run(() =>
            {
                Log.Write(Log.Type.DEBUG, "Инициализация подключения к SQL Server.");
                try
                {

                    _con = new SqlConnection(string.Format(@"Server={0};Database={1};User ID={2};Password={3};MultipleActiveResultSets=true;Connection Timeout=3",
                        Settings.Default.ServerName, Settings.Default.DBName, Settings.Default.User, Settings.Default.Password));

                    _con.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    Log.Write(Log.Type.ERROR, string.Format("Ошибка инициализации подключения к SQL Server:\n{0}", ex.Message));
                    ExceptionText = ex.Message;
                    return false;
                }
            });
        }

        public static void Close()
        {
            if (_con != null)
                if (_con.State == System.Data.ConnectionState.Open)
                {
                    _con.Close();
                    _con.Dispose();
                }
        }

        public static Task<DataTable> GetTable(string query)
        {
            return Task.Run(() =>
            {
                try
                {
                    SqlCommand com = new SqlCommand(query, _con);
                    com.CommandTimeout = 86400;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    Log.Write(Log.Type.ERROR, string.Format("Соединение с SQL Server потеряно:\n{0}", ex.Message));
                    return null;
                }
            });
        }

        public static Task<string> GetScalar(string query)
        {
            return Task.Run(() =>
            {
                try
                {
                    return new SqlCommand(query, _con).ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    Log.Write(Log.Type.ERROR, string.Format("Соединение с SQL Server потеряно:\n{0}", ex.Message));
                    return null;
                }
            });
        }

        public static Task<DataTable> Compare(Person person)
        {
            return Task.Run(() =>
            {

                SqlCommand com = new SqlCommand("Compare", _con) { CommandType = CommandType.StoredProcedure };
                try
                {
                    com.CommandTimeout = 86400;
                    com.Parameters.AddWithValue("@FIO", person.FIO);
                    com.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth.ToString("yyyyMMdd"));
                    com.Parameters.AddWithValue("@DateExpire", person.DateExpire.ToString("yyyyMMdd"));
                    com.Parameters.AddWithValue("@Route", person.Route);
                    com.Parameters.AddWithValue("@Mark", person.Index);
                    com.Parameters.AddWithValue("@TaskKey", person.TaskKey);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Log.Write(Log.Type.ERROR, string.Format("Соединение с SQL Server потеряно:\n{0}", ex.Message));
                    return null;
                }
            });
        }

        public static Task Change(Int64 IdPerson, int idTelegram)
        {
            return Task.Run(() =>
            {
                SqlCommand com = new SqlCommand("Change", _con) { CommandType = CommandType.StoredProcedure };
                try
                {
                    com.CommandTimeout = 86400;
                    com.Parameters.AddWithValue("@IdPerson", IdPerson);
                    com.Parameters.AddWithValue("@IdTelegram", idTelegram);
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Log.Write(Log.Type.ERROR, string.Format("Соединение с SQL Server потеряно:\n{0}", ex.Message));
                }
            });
        }

        public static Task<int> InsertTelegram(string number, DateTime dateofSigning, string description = "")
        {
            return Task.Run(() =>
            {
                SqlCommand com = new SqlCommand("InsertTelegram", _con) { CommandType = CommandType.StoredProcedure };
                try
                {
                    com.CommandTimeout = 86400;
                    com.Parameters.AddWithValue("@Number", number);
                    com.Parameters.AddWithValue("@DateofSigning", dateofSigning.ToString("yyyyMMdd"));
                    com.Parameters.AddWithValue("@Description", description);
                    int id = 0;
                    com.Parameters.AddWithValue("@Id", id).Direction = ParameterDirection.Output;
                    com.ExecuteNonQuery();
                    return com.Parameters[3].Value == DBNull.Value ? -1 : (int)com.Parameters[3].Value;
                }
                catch (Exception ex)
                {
                    Log.Write(Log.Type.ERROR, string.Format("Соединение с SQL Server потеряно:\n{0}", ex.Message));
                    return -1;
                }

            });
        }

        public static Task<int> InsertPerson(Person person, int idTelegram)
        {
            return Task.Run(() =>
            {
                SqlCommand com = new SqlCommand("InsertPerson", _con) { CommandType = CommandType.StoredProcedure };
                try
                {
                    com.CommandTimeout = 86400;
                    com.Parameters.AddWithValue("@IdTelegram", idTelegram);
                    com.Parameters.AddWithValue("@FIO", person.FIO);
                    com.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth == DateTime.MinValue ? (object)DBNull.Value : person.DateOfBirth.ToString("yyyyMMdd"));
                    com.Parameters.AddWithValue("@DateExpire", person.DateExpire == DateTime.MinValue ? (object)DBNull.Value : person.DateExpire.ToString("yyyyMMdd"));
                    com.Parameters.AddWithValue("@Sex", string.IsNullOrWhiteSpace(person.Sex) ? (object)DBNull.Value : person.Sex);
                    com.Parameters.AddWithValue("@Task", person.Task);
                    com.Parameters.AddWithValue("@TaskKey", person.TaskKey);
                    com.Parameters.AddWithValue("@Country", string.IsNullOrWhiteSpace(person.Country) ? (object)DBNull.Value : person.Country);
                    com.Parameters.AddWithValue("@Mark", person.Index);
                    com.Parameters.AddWithValue("@Route", person.Route);
                    com.Parameters.AddWithValue("@Additionally", person.Additionally == null ? (object)DBNull.Value : person.Additionally);
                    com.Parameters.AddWithValue("@PlaceOfBirth", person.PlaceOfBirth == null ? (object)DBNull.Value : person.PlaceOfBirth);
                    com.Parameters.AddWithValue("@IdPerson", 0).Direction = ParameterDirection.Output;
                    com.ExecuteNonQuery();
                    return com.Parameters[12].Value == DBNull.Value ? 0 : 1;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    Log.Write(Log.Type.ERROR, string.Format("Соединение с SQL Server потеряно:\n{0}", ex.Message));
                    return 0;
                }
            });
        }

        public async static void Start()
        {
            SqlCommand com1 = new SqlCommand(@"SELECT p.UserId, p.DateOfInsert,t.Number, t.DateOfSigning, p.Name,  p.DateOfBirth , p.DateOfDelete, p.Sex, p.Task, p.IsDelete, 
c.Abbr, m.Abbr, pr.RouteId, p.DateOfChange, p.Additionally, p.PlaceOfBirth, p.Id  from [db].dbo.Person p
inner join [db].dbo.PersonRoute pr on pr.PersonId=p.Id
inner join [db].dbo.PersonTelegram pt on pt.PersonId=p.Id
inner join [db].dbo.Telegram t on t.Id=pt.TelegramId
inner join [db].dbo.Mark m on m.Id=pr.MarkId
left join [db].dbo.Country c on c.Id=p.CountryId where p.IsDelete = 0  ", _con) { CommandType = CommandType.Text };
            com1.CommandTimeout = 86400;
            using (SqlDataReader rdr = com1.ExecuteReader())
            {
                int id = 0;
                while (rdr.Read())
                {
                    var idTel = await InsertTelegram(rdr.GetString(2), rdr.GetDateTime(1));
                    await Task.Run(() =>
                     {
                         SqlCommand com = new SqlCommand("InsertPerson1", _con) { CommandType = CommandType.StoredProcedure };
                         try
                         {
                             com.CommandTimeout = 86400;

                             var d = rdr.IsDBNull(5) || string.IsNullOrWhiteSpace(rdr.GetString(5)) ? "" : rdr.GetString(5);
                             d = d.Trim().Length == 2 ? d.Trim().Insert(0, "0101") : d.Replace("0000", "0101");
                             d = string.IsNullOrWhiteSpace(d) || d.Length != 6 ? "000000" : d;
                             com.Parameters.AddWithValue("@IdTelegram", idTel);
                             com.Parameters.AddWithValue("@FIO", rdr.GetString(4));
                             com.Parameters.AddWithValue("@DateOfBirth", DateTime.TryParse($"{d[0]}{d[1]}.{d[2]}{d[3]}.{(int.Parse($"{d[4]}{d[5]}") < 30 ? "20" : "19")}{d[4]}{d[5]}", out DateTime dateB) ? dateB.ToString("yyyyMMdd") : (object)DBNull.Value);
                             com.Parameters.AddWithValue("@DateExpire", rdr.IsDBNull(7) ? (object)DBNull.Value : rdr.GetDateTime(6).ToString("yyyyMMdd"));
                             com.Parameters.AddWithValue("@Sex", rdr.IsDBNull(7) || string.IsNullOrWhiteSpace(rdr.GetString(7)) ? (object)DBNull.Value : rdr.GetString(7) == "М" ? true : false);
                             com.Parameters.AddWithValue("@Task", rdr.GetString(8));
                             com.Parameters.AddWithValue("@TaskKey", DBNull.Value);
                             com.Parameters.AddWithValue("@Country", rdr.IsDBNull(10) || string.IsNullOrWhiteSpace(rdr.GetString(10)) ? (object)DBNull.Value : rdr.GetString(10));
                             com.Parameters.AddWithValue("@Mark", rdr.GetString(11));
                             com.Parameters.AddWithValue("@Route", rdr.GetByte(12) == 1 ? true : false);
                             com.Parameters.AddWithValue("@IsDel", rdr.GetBoolean(9));
                             com.Parameters.AddWithValue("@IdUser", rdr.GetInt16(0));
                             com.Parameters.AddWithValue("@DateChange", rdr.IsDBNull(13) ? (object)DBNull.Value : rdr.GetDateTime(13).ToString("yyyyMMdd HH:mm:ss"));
                             com.Parameters.AddWithValue("@DateAdd", rdr.GetDateTime(1).ToString("yyyyMMdd HH:mm:ss"));
                             com.Parameters.AddWithValue("@Additionally", rdr.IsDBNull(14) || string.IsNullOrWhiteSpace(rdr.GetString(14)) ? (object)DBNull.Value : rdr.GetString(14));
                             com.Parameters.AddWithValue("@PlaceOfBirth", rdr.IsDBNull(15) || string.IsNullOrWhiteSpace(rdr.GetString(15)) ? (object)DBNull.Value : rdr.GetString(15));
                             com.ExecuteNonQuery();
                             Application.OpenForms[0].Invoke(new MethodInvoker(() => EditForm.Instance.lNumber.Text = $"Количество:{++id}"));
                         }
                         catch (Exception ex)
                         {
                             Log.Write(Log.Type.ERROR, $"\n{ex.Message}");
                             try
                             {
                                 Log.Write(Log.Type.ERROR, $"\n{rdr.GetInt64(16)}");
                             }
                             catch { }
                         }
                     });
                }
                System.Windows.Forms.MessageBox.Show("Конец");
            }
        }

        public static Task<int> PersonDereg(string taskKey, int idTelegram)
        {
            return Task.Run(() =>
            {
                SqlCommand com = new SqlCommand("PersonDereg", _con) { CommandType = CommandType.StoredProcedure };
                try
                {
                    com.CommandTimeout = 86400;
                    com.Parameters.AddWithValue("@TaskKey", taskKey);
                    com.Parameters.AddWithValue("@IdTelegram", idTelegram);
                    return com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    Log.Write(Log.Type.ERROR, string.Format("Соединение с SQL Server потеряно:\n{0}", ex.Message));
                    return 0;
                }
            });
        }
        public static Task<DataTable> Find(string filter)
        {
            return Task.Run(() =>
            {
                SqlCommand com = new SqlCommand("Find", _con) { CommandType = CommandType.Text };
                try
                {
                    com.CommandTimeout = 86400;
                    com.CommandText = @"
select p.Id, p.IsDeleted [Снят], p.FIO [ФИО], p.DateOfBirth [Дата рождения], m.Name [Отметка], t.Number [Номер телеграммы], t.DateOfSigning [Дата подписания],
p.DateExpire [Срок контроля], p.Task [Задание], us.FIO [Пользователь] from Person p
inner join TelegramPerson pt on pt.IdPerson=p.Id
inner join Telegram t on t.Id=pt.IdTelegram  
inner join [Mark] m on m.Id=p.IdMark 
inner join UserAction u on u.IdPerson = p.Id
inner join [User] us on us.Id=u.IdUser " + (string.IsNullOrWhiteSpace(filter) ? "" : filter.Trim().Insert(0, "where").Replace("whereand", "where")) +
@" group by  p.Id, p.IsDeleted  , p.FIO  , p.DateOfBirth , m.Name , t.Number , t.DateOfSigning ,
p.DateExpire  , p.Task , us.FIO ";
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    Log.Write(Log.Type.ERROR, string.Format("Соединение с SQL Server потеряно:\n{0}", ex.Message));
                    return null;
                }
            });
        }

    }
}
