﻿using System;
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

using System.Configuration;

namespace ALUMNI_APP
{
    public partial class Form1 : Form
    {
        private string ID {get;set;}
        private string password { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        bool isStudent()
        {
            DataBase foo = DataBase.GetInstance();
            JObject json = foo.Query();
            var searchResults = from rr in json["Students"]
                                where rr["ID_Student"].ToString() == ID && rr["Password"].ToString() == password
                                select rr;
            int i = 0;
            foreach (var rr in searchResults)
            {
                i++;
            }
            if (i > 0) return true;
            return false;
        }

        bool isProfessor()
        {
            DataBase foo = DataBase.GetInstance();
            JObject json = foo.Query();
            var searchResults = from rr in json["Professors"]
                                where rr["ID_Professor"].ToString() == ID && rr["Password"].ToString() == password
                                select rr;
            int i = 0;
            foreach (var rr in searchResults)
            {
                i++;
            }
            if (i > 0) return true;
            return false;
        }

        bool isSupervisor()
        {
            DataBase foo = DataBase.GetInstance();
            JObject json = foo.Query();
            var searchResults = from rr in json["Supervisors"]
                                where rr["ID_Supervisor"].ToString() == ID && rr["Password"].ToString() == password
                                select rr;
            int i = 0;
            foreach (var rr in searchResults)
            {
                i++;
            }
            if (i > 0) return true;
            return false;
        }

        /// <summary>
        /// Validating user's credentials
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            password = PasswordUser.Text;
            ID = ID_User.Text;

            if (isStudent())
            {
                StudentsForm userStudent = new StudentsForm();
                this.Hide();
                userStudent.ID = ID;
                userStudent.Show();
            }
            else if (isProfessor())
            {
                ProfessorForm userProfessor = new ProfessorForm();
                this.Hide();
                userProfessor.ID = ID;
                userProfessor.Show();
            }
            else if (isSupervisor())
            {
                SupervisorForm userStudent = new SupervisorForm();
                this.Hide();
                userStudent.ID = ID;
                userStudent.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials! Try it again");
            }
        }
    }
}
