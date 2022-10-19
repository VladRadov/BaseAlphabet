using System;

using Alphabet.Model;

namespace Alphabet.Service
{
    internal class Logger
    {
        public static void Writer(params BaseWriteLogger[] writeLoggers)
        {
            foreach (var writeLogger in writeLoggers)
                writeLogger.Write();
        }
    }

    class BaseAttributeLog
    {
        public DateTime DateTimeCreate { get; set; }
    }

    class AttributeSystemLog : BaseAttributeLog
    {
        public string LevelMessage { get; set; }

        public string Message { get; set; }
    }

    class AttributeUserActionLog : BaseAttributeLog
    {
        public string LoginUser { get; set; }

        public string NameUserActionType { get; set; }

        public int IdPerson { get; set; }
    }

    class BaseWriteLogger
    {
        public virtual void Write()
        {

        }
    }

    class SQLWriteSystemLogger : BaseWriteLogger
    {
        private AttributeSystemLog _attributeLog;

        public SQLWriteSystemLogger(AttributeSystemLog attributeLog)
        {
            _attributeLog = attributeLog;
        }

        public override void Write()
        {
            if (UserSessions.Instance.User != null)
                _attributeLog.Message = " Операция выполнялась от пользователя: " + UserSessions.Instance.User.Login;

            var addRecordToLog = new AddRecordToLog(_attributeLog.DateTimeCreate, _attributeLog.LevelMessage, _attributeLog.Message);
            addRecordToLog.Execute();
        }
    }

    class SQLWriteUserActionLogger : BaseWriteLogger
    {
        private AttributeUserActionLog _attributeLog;

        public SQLWriteUserActionLogger(AttributeUserActionLog attributeLog)
        {
            _attributeLog = attributeLog;
        }

        public override void Write()
        {
            var addRecordToLog = new InsertRecordUserAction(_attributeLog.DateTimeCreate, _attributeLog.LoginUser, _attributeLog.NameUserActionType, _attributeLog.IdPerson);
            addRecordToLog.Execute();
        }
    }
}
