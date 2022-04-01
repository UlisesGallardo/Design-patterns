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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password, id;
            password = PasswordUser.Text;
            id = ID_User.Text;

            /*Singleton*/
            DataBase foo = DataBase.GetInstance();
            JObject json = foo.Query();
            var searchResults = from rr in json["Students"]
                                where rr["ID_Student"].ToString() == id && rr["Password"].ToString() == password
                                select rr;
            int i = 0;
            foreach (var rr in searchResults)
            {
                //Console.WriteLine(rr);
                i++;
            }
            if (i == 0)
            {
                MessageBox.Show("Credenciales invalidas! Intenta de nuevo");
            } else
            {
                //Instanciate a new winwdos form
                StudentForm userStudent = new StudentForm();
                this.Hide();
                userStudent.ID = id;
                userStudent.Show();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //Para cambiar los paneles
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            //panel
        }
    }
}
