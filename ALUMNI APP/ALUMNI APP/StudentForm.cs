using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ALUMNI_APP
{
    public partial class StudentForm : Form
    {
        public string ID { get; set; }
        User user = null;

        private List<string> info;
        private List<JToken> searchResultsGrades;
        private DataTable tb_grades { get; set; }

        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void StudentForm_Load_1(object sender, EventArgs e)
        {
            UserCreator creator = null;
            creator = new StudentCreator();
            user = creator.CreateUser(ID);
            info = user.GetInformation();
            searchResultsGrades = user.GetCalifications();
            tb_grades = user.GradesToTable();
        }

        private void guna2Buttons_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("Name");
            list.Add("Carrer");
            list.Add("YearOfBirth");
            list.Add("City");
            BasicInformation bi = new BasicInformation();
            bi.info = info;
            bi.NamesRows = list;
            AddUserControl(bi);
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //Grades -> Subject | p1 | p2 | p3 | Final
            Grades grades = new Grades();
            grades.dt = tb_grades;
            grades.user = "Student";
            AddUserControl(grades);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
            var formToShow = Application.OpenForms.Cast<Form>()
            .FirstOrDefault(c => c is Form1);
                    if (formToShow != null)
                    {
                        formToShow.Show();
                    }
            this.Dispose();
        }
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

    }
}
