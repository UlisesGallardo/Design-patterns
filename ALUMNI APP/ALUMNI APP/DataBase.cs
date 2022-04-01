using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ALUMNI_APP
{
    class DataBase
    {
        private static DataBase _instance = null;
        public static DataBase GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataBase();
            }
            return _instance;
        }

        public JObject Query()
        {
            StreamReader r = new StreamReader("data.json");
            string jsonString = r.ReadToEnd();
            JObject json = (JObject)JsonConvert.DeserializeObject(jsonString);
            return json;
        }
    }
}
