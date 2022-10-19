﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EditingRegistrationApp
{
    public static class Log
    {
        private const string _fileName = "log";

        public enum Type
        {
            //сообщения отладки
            DEBUG,
            //сообщения о действиях
            INFO,
            //сообщения о предупреждениях
            WARNING,
            //сообщения об ошибках 
            ERROR,
        }

        static Log()
        {
            Write(Type.DEBUG, "Начало работы. " + EditForm.usr);
        }

        public static Task Init()
        {
            return Task.Run(() =>
            {
                if (!File.Exists(_fileName))
                    File.Create(_fileName);
                // Если файл лога превысил 10 МБ, то создаем резервную копию
                if (new FileInfo(_fileName).Length > 10485760)
                {
                    File.Move(_fileName, string.Format("log {0}{1}{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                }
            });
        }

        public static void Write(Type type, string text)
        {
            string res = string.Format("{0} [{1}] {2}", DateTime.Now, Enum.GetName(typeof(Type), type), text);
            File.AppendAllLines(_fileName, new string[] { res });
        }

        public static string[] Read()
        {
            return File.ReadAllLines(_fileName);
        }
    }
}
