using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json.Linq;
using System.IO;

using System.Configuration;
using Microsoft.Office.Interop.Word;

namespace ALUMNI_APP
{
    public partial class Grades : UserControl
    {
        public System.Data.DataTable dt { get; set; }
        public string user { get; set; }

        public Grades()
        {
            InitializeComponent();
        }

        private void Grades_Load(object sender, EventArgs e)
        {
            GradeGrid.DataSource = dt;
            GradeGrid.ColumnHeadersHeight = 40;
            if(user == "Professor")
            {
                Btn_Download.Visible = false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings["OutputFormat"] ?? "Not Found";
            Console.WriteLine(result);
            
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (result == "Docx")
            {
               saveFileDialog.FileName = "Grades";
            }
            else if (result == "Txt")
            {
                saveFileDialog.FileName = "Grades.txt";
            }


            saveFileDialog.FilterIndex = 2;
             saveFileDialog.RestoreDirectory = true;
             bool fileError = false;
             if (saveFileDialog.ShowDialog() == DialogResult.OK)
             {
                 //if ((myStream = saveFileDialog.OpenFile()) != null)
                 //{
                     if (File.Exists(saveFileDialog.FileName))
                     {
                         try
                         {
                             File.Delete(saveFileDialog.FileName);
                         }
                         catch (IOException ex)
                         {
                             fileError = true;
                             MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                         }
                     }

                        if(!fileError)
                        {
                            try
                            {
                          
                                if (result == "Docx")
                                {
                                    //saveFileDialog.DefaultExt = "docx";
                                    //saveFileDialog.Filter = "word files (*.docx)|*.docx";
                                    saveDocx(saveFileDialog.FileName);
                                }else if (result == "Txt")
                                {
                                    saveFileDialog.DefaultExt = "txt";
                                    saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                                    saveTxt(saveFileDialog.FileName);
                                }

                                MessageBox.Show("Data Exported Successfully !!!", "Info");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error :" + ex.Message);
                            }
                   
                        }
                        //myStream.Close();
                //}
            }
        }

        private void GradeGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void GradeGrid_CancelRowEdit(object sender, QuestionEventArgs e)
        {

        }

        private void saveDocx(object filename)
        {
            var word = new Microsoft.Office.Interop.Word.Application();
            word.Visible = true;
            word.WindowState = WdWindowState.wdWindowStateNormal;

            Microsoft.Office.Interop.Word.Document doc = word.Documents.Add();
            Microsoft.Office.Interop.Word.Table table = doc.Tables.Add(word.Selection.Range, 1, dt.Columns.Count);

            int jj = 0;
            foreach (DataColumn col in dt.Columns)
            {
                table.Cell(0, jj + 1).Range.Text = col.ToString();
                jj++;
            }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                table.Rows.Add();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    table.Cell(i + 2, j + 1).Range.Text = dt.Rows[i][j].ToString();
                }
            }
            doc.SaveAs2(filename);
            doc.Close();
            word.Quit();
        }

        private void saveTxt(string filename)
        {
            int columnCount = GradeGrid.Columns.Count; //convertir tb_grades to string
            string columnNames = "";
            string[] output = new string[GradeGrid.Rows.Count + 1];
            for (int i = 0; i < columnCount; i++)
            {
                columnNames += GradeGrid.Columns[i].HeaderText.ToString() + "\t\t\t\t";
            }
            output[0] += columnNames;

            for (int i = 0; i < GradeGrid.Rows.Count; i++)
            {
                output[i] += "\n";
                for (int j = 0; j < columnCount; j++)
                {
                    if (GradeGrid.Rows[i].Cells[j].Value != null)
                    {
                        output[i] += GradeGrid.Rows[i].Cells[j].Value.ToString() + "\t\t\t\t";
                    }
                }

            }
            File.WriteAllLines(filename, output, Encoding.UTF8);
        }
    }
}
