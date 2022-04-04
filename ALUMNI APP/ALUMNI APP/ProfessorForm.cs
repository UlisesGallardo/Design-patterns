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
    public partial class ProfessorForm : Form
    {
        public string ID { get; set; }
        User user = null;

        private List<string> info;
        private List<JToken> searchResultsGrades;
        private DataTable tb_grades { get; set; }

        public ProfessorForm()
        {
            InitializeComponent();
        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Grades grades = new Grades();
            grades.dt = tb_grades;
            grades.user = "Professor";
            AddUserControl(grades);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("Name");
            list.Add("Degree");
            list.Add("YearOfBirth");
            list.Add("City");
            BasicInformation bi = new BasicInformation();
            bi.info = info;
            bi.NamesRows = list;
            AddUserControl(bi);
        }

        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void ProfessorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Creating a professor user with factory 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ProfessorForm_Load(object sender, EventArgs e)
        {
            UserCreator creator = null;
            creator = new ProfessorCreator();
            user = creator.CreateUser(ID);
            info = user.GetInformation();
            searchResultsGrades = user.GetCalifications();
            tb_grades = user.GradesToTable();
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

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
