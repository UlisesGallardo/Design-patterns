using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

using System.Configuration;


namespace ALUMNI_APP
{
    class DataBase
    {
        private static DataBase _instance = null;
        private JObject json;
        public static DataBase GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataBase();
            }
            return _instance;
        }

        

        private DataBase()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings["InputFormat"] ?? "Not Found";
            Console.WriteLine(result);
            if (result == "Json")
            {
                readJson();
            }
            else if(result == "Yaml")
            {
                readYAML();
            }
        }

        /// <summary>
        /// Converting input data with yaml format to Json using Adapter
        /// </summary>

        private void readYAML(){
            Yaml yaml = new Yaml();
            IDataAdapter adapter = new YamlToJson(yaml);
            var jsonString = adapter.convert();
            JObject json = (JObject)JsonConvert.DeserializeObject(jsonString);
            this.json = json;
        }

        private void readJson()
        {
            StreamReader r = new StreamReader("data.json");
            string jsonString = r.ReadToEnd();
            JObject json = (JObject)JsonConvert.DeserializeObject(jsonString);
            this.json = json;
        }

        public JObject Query()
        {
            return json;
        }
    }
}
