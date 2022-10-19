using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EditingRegistrationApp
{
    public static class FileOperations
    {
        public static Task Read(string path, int type, int route)
        {
            return Task.Run(() =>
            {
                Log.Write(Log.Type.DEBUG, "Загрузка списка ОУ.");

                try
                {
                    int i = 0;
                    Person person = null;
                    foreach (var line in File.ReadLines(path, Encoding.GetEncoding(866)))
                    {
                        if (i % 2 == 0)
                        {
                            var d = line.Substring(68, 6).Trim().Length == 2 ? line.Substring(68, 6).Trim().Insert(0,  "0101"): line.Substring(68, 6).Replace("0000", "0101");

                            person = new Person
                            {
                                FIO = string.Join(" ", line.Substring(75).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)),
                                DateExpire = DateTime.TryParse(line.Substring(29, 10), out DateTime dateExp) ? dateExp : DateTime.MinValue,
                                Index = line.Substring(59, 1),

                                DateOfBirth = DateTime.TryParse($"{d[0]}{d[1]}.{d[2]}{d[3]}.{(int.Parse($"{d[4]}{d[5]}") < 30 ? "20" : "19")}{d[4]}{d[5]}", out DateTime dateB) ? dateB : DateTime.MinValue,
                                Sex = line.Substring(61, 1),
                                Country = line.Substring(63, 4),
                                Id = Person.List.Count + 1,
                                Type = type,
                                Route = route
                            };
                        }
                        else
                        {
                            person.Task = line;
                            var l = line.Split(new string[] { "" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            var taskKey = l.FirstOrDefault(x => x.Contains("TaskKey"));
                            var additionally = l.FirstOrDefault(x => x.Contains("Дополнительная информация:"));
                            var placeOfBirth = l.FirstOrDefault(x => x.Contains("Место рождения:"));
                            if (taskKey != null)
                                person.TaskKey = taskKey.Split(new string[] { "TaskKey" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                            if (additionally != null)
                                person.Additionally = additionally.Split(new string[] { "Дополнительная информация:" }, StringSplitOptions.RemoveEmptyEntries)[0].Replace("Дополнительная информация:", "");
                            if (placeOfBirth != null)
                                person.PlaceOfBirth = placeOfBirth.Split(new string[] { "Место рождения:" }, StringSplitOptions.RemoveEmptyEntries)[0].Replace("Место рождения:", "");
                            Application.OpenForms[0].Invoke(new MethodInvoker(() => Person.List.Add(person)));
                        }
                        i++;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки списка ОУ:\n" + ex.Message);
                    Log.Write(Log.Type.DEBUG, "Ошибка загрузки списка ОУ:\n" + ex.Message);
                }
            });
        }
    }
}

