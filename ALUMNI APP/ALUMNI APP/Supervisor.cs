using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ALUMNI_APP
{
    class Supervisor : User
    {
        public string Name { get; set; }
        private int YearOfBirth { set; get; }
        private string City { set; get; }
        private string ID { set; get; }

        public Supervisor(string ID)
        {
            this.ID = ID;
            DataBase foo = DataBase.GetInstance();
            JObject json = foo.Query();
            var searchResults = from rr in json["Supervisors"]
                                where rr["ID_Supervisor"].ToString() == ID
                                select rr;
            foreach (var rr in searchResults)
            {
                Console.WriteLine(rr.First);
                Name = rr["Name"].ToString();
                YearOfBirth = Int32.Parse(rr["YearOfBirth"].ToString());
                City = rr["City"].ToString();
            }
        }
        public override List<string> GetInformation()
        {
            List<string> info = new List<string>();
            info.Add(Name);
            info.Add(YearOfBirth.ToString());
            info.Add(City);
            return info;
        }

        public override List<JToken> GetCalifications()
        {
            return null;
        }

        public override DataTable GradesToTable()
        {
            return null;
        }
    }
}
