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
    class Professor : User
    {
        public string Name { get; set; }
        private int YearOfBirth { set; get; }
        private string City { set; get; }

        private string Degree { set; get; }

        private string ID { set; get; }
        private DataTable tb_grades { get; set; }

        public Professor(string ID)
        {
            this.ID = ID;
            DataBase foo = DataBase.GetInstance();
            JObject json = foo.Query();
            var searchResults = from rr in json["Professors"]
                                where rr["ID_Professor"].ToString() == ID
                                select rr;
            foreach (var rr in searchResults)
            {
                Console.WriteLine(rr.First);
                Name = rr["Name"].ToString();
                YearOfBirth = Int32.Parse(rr["YearOfBirth"].ToString());
                City = rr["City"].ToString();
                Degree = rr["Degree"].ToString();
            }
        }
        public override List<string> GetInformation()
        {
            List<string> info = new List<string>();
            info.Add(Name);
            info.Add(Degree);
            info.Add(YearOfBirth.ToString());
            info.Add(City);
            return info;
        }

        public List<string> GetSubjects()
        {
            DataBase foo = DataBase.GetInstance();
            JObject json = foo.Query();
            var searchResults = from r in json["SubjectsANDProfessors"]
                                where r["ID_Professor"].ToString() == ID
                                select r;
            List<string> id = new List<string>();
            foreach (var rr in searchResults)
            {
                id.Add(rr["ID_Subject"].ToString());
            }
            return id;
        }
        public override List<JToken> GetCalifications()
        {
                List<JToken> students = new List<JToken>();
                DataBase foo = DataBase.GetInstance();
                JObject json = foo.Query();
                var searchResults = from r in json["Grades"]
                                    where r["ID_Professor"].ToString() == ID
                                    select r;
                foreach (var rrr in searchResults)
                {
                    students.Add(rrr);
                }
            return students;
        }
        public override DataTable GradesToTable()
        {
            tb_grades = new DataTable();
            DataRow dr = null;
            tb_grades.Columns.Add(new DataColumn("Student's Name", typeof(string)));
            tb_grades.Columns.Add(new DataColumn("Subject", typeof(string)));
            tb_grades.Columns.Add(new DataColumn("P1", typeof(string)));
            tb_grades.Columns.Add(new DataColumn("P2", typeof(string)));
            tb_grades.Columns.Add(new DataColumn("P3", typeof(string)));
            tb_grades.Columns.Add(new DataColumn("Final", typeof(string)));

            List<JToken> students = new List<JToken>();
            students = GetCalifications();

            foreach (var rr in students)
            {
                string id_subject = rr["ID_Subject"].ToString();
                string id_student = rr["ID_Student"].ToString();

                DataBase foo = DataBase.GetInstance();
                JObject json = foo.Query();
                var searchResults = from r in json["Subjects"]
                                    where r["ID_Subject"].ToString() == id_subject
                                    select r;
                dr = tb_grades.NewRow();
                dr["Subject"] = searchResults.First()["Name"].ToString();

                searchResults = from r in json["Students"]
                                    where r["ID_Student"].ToString() == id_student
                                select r;

                dr["Student's Name"] = searchResults.First()["Name"].ToString();
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
