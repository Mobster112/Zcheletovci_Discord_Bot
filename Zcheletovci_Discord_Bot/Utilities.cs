using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Zcheletovci_Discord_Bot
{
    class Utilities
    {
        private static Dictionary<string, string> alerts;
        static Utilities()
        {
            string json = File.ReadAllText("SystemLang/alerts.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);

            alerts = data.ToObject<Dictionary<string, string>>();
        }

        public static string GetAlert(string key)
        {
            if (alerts.ContainsKey(key)) return alerts[key];
            return "";
        }
    }
}
