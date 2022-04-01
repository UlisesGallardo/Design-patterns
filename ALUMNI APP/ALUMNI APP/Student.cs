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
    class Student : User
    {
        private string Name { set; get; }
        private string  Career { set; get; }
        private int YearOfBirth { set; get; }
        private string City { set; get; }
        private string ID { set; get; }
        private List<JToken> grades { set; get; }
        private  DataTable tb_grades { get; set; }

        public Student(string ID)
        {
            this.ID = ID;
            DataBase foo = DataBase.GetInstance();
            JObject json = foo.Query();
            var searchResults = from rr in json["Students"]
                                where rr["ID_Student"].ToString() == ID
                                select rr;
            //Console.WriteLine("Obteniendo informacion:");
            foreach (var rr in searchResults)
            {
                Console.WriteLine(rr.First);
                Name = rr["Name"].ToString();
                Career = rr["Carrer"].ToString();
                YearOfBirth = Int32.Parse(rr["YearOfBirth"].ToString());
                City = rr["City"].ToString();
            }
            /*
            Console.WriteLine("Propiedades:");
            
            JToken s = searchResults.First();
            JObject res = (JObject)s;
            IList<string> keys = res.Properties().Select(p => p.Name).ToList();
            foreach (JToken rr in keys)
            {
                Console.WriteLine(rr);
            }*/
        }

        public override List<string> GetInformation()
        {
            List<string> info = new List<string>();
            info.Add(Name);
            info.Add(Career);
            info.Add(YearOfBirth.ToString());
            info.Add(City);
            return info;
        }

        public override IEnumerable<JToken> GetCalifications()
        {
            DataBase foo = DataBase.GetInstance();
            JObject json = foo.Query();
            var searchResults = from rr in json["Grades"]
                                where rr["ID_Student"].ToString() == ID
                                select rr;
            
            /*
                Console.WriteLine("Entrando a las calificaciones del alumno:");
                foreach (var rr in searchResults)
                {
                    Console.WriteLine(rr);
                }
            */
            return searchResults;
        }

        public void DonwloadCalifications()
        {
            DataBase foo = DataBase.GetInstance();
            JObject json = foo.Query();
            var searchResults = from rr in json["Grades"]
                                where rr["ID_Student"].ToString() == ID
                                select rr;
            JToken s = searchResults.First();

            foreach (var rr in searchResults)
            {
                grades.Add(rr);
            }
        }

        public override DataTable GradesToTable()
        {
            tb_grades = new DataTable();
            DataRow dr = null;
            tb_grades.Columns.Add(new DataColumn("Subject", typeof(string)));
            tb_grades.Columns.Add(new DataColumn("P1", typeof(string)));
            tb_grades.Columns.Add(new DataColumn("P2", typeof(string)));
            tb_grades.Columns.Add(new DataColumn("P3", typeof(string)));
            tb_grades.Columns.Add(new DataColumn("Final", typeof(string)));

            var searchResultsGrades = GetCalifications();
            foreach (var rr in searchResultsGrades)
            {
                string id_subject = rr["ID_Subject"].ToString();

                DataBase foo = DataBase.GetInstance();
                JObject json = foo.Query();
                var searchResults = from r in json["Subjects"]
                                    where r["ID_Subject"].ToString() == id_subject
                                    select r;
                dr = tb_grades.NewRow();
                dr["Subject"] = searchResults.First()["Name"].ToString();
                dr["P1"] = rr["FirstPartial"].ToString();
                dr["P2"] = rr["SecondPartial"].ToString();
                dr["P3"] = rr["ThirdPartial"].ToString();
                dr["Final"] = rr["FinalAverage"].ToString();
                tb_grades.Rows.Add(dr);
            }
            return tb_grades;
        }
    }
}
