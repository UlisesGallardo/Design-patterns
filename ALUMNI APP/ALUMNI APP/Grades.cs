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

namespace ALUMNI_APP
{
    public partial class Grades : UserControl
    {
        public DataTable dt { get; set; }

        public Grades()
        {
            InitializeComponent();
        }

        private void Grades_Load(object sender, EventArgs e)
        {
            GradeGrid.DataSource = dt;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //saveFileDialog.FileName = "cal";
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
                            /*convertir tb_grades to string*/
                            int columnCount = GradeGrid.Columns.Count;
                            string columnNames = "";
                            string[] output = new string[GradeGrid.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += GradeGrid.Columns[i].HeaderText.ToString() + "\t\t";
                            }
                            output[0] += columnNames;

                            for (int i = 0; i < GradeGrid.Rows.Count; i++)
                            {
                                output[i] += "\n";
                                for (int j = 0; j < columnCount; j++)
                                {
                                    if (GradeGrid.Rows[i].Cells[j].Value != null)
                                    {
                                        output[i] += GradeGrid.Rows[i].Cells[j].Value.ToString() + "\t\t";
                                    }
                                }
                                
                            }


                            File.WriteAllLines(saveFileDialog.FileName, output, Encoding.UTF8);
                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                        //myStream.Close();
                    }
               // }
            }
        }
    }
}
