using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Adm
{
    namespace Tools
    {
        /// <summary>
        /// Класс, реализующий получение и установку значений счетчиков на сайте
        /// </summary>
        public static class Counters
        {
            public static int GetValue(string Counter, HttpServerUtility server)
            {
                if (File.Exists(server.MapPath("~/app_data/counters/" + Counter)))
                {
                    string value = File.ReadAllText(server.MapPath("~/app_data/counters/" + Counter));
                    int res = 0;
                    if (int.TryParse(value, out res))
                    {
                        return res;
                    }
                }
                return 0;
            }

            public static void SetValue(string Counter, int Value, HttpServerUtility server)
            {
                File.WriteAllText(server.MapPath("~/app_data/counters/" + Counter), Value.ToString());
            }
        }
    }
}