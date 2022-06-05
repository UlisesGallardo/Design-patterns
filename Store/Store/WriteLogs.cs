using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class WriteLogs : Form
    {
        private static WriteLogs _instance = null;
        public Log logs;
        private TxtFileForm _txt_form;
        private TextBox _txt_box;
        private DataGrid _data_grid;

        protected WriteLogs()
        {
            InitializeComponent();
        }

        public static WriteLogs GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WriteLogs();
            }
            return _instance;
        }

        private void WriteLogs_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.Text = "Selecciona una opcion";
            guna2ComboBox1.Items.Add("TxtFile");
            guna2ComboBox1.Items.Add("Grid");
            guna2ComboBox1.Items.Add("TextBox");
            logs = new Log();
            _txt_form = new TxtFileForm();
            _txt_box = new TextBox();
            _data_grid = new DataGrid();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            string selected = guna2ComboBox1.SelectedIndex.ToString();
            if (selected == "0")
            {
                logs.setLogger(new TxtFile());
                flowLayoutPanel1.Controls.Add(_txt_form);
            }else if (selected == "1")
            {
                logs.setLogger(_data_grid);
                flowLayoutPanel1.Controls.Add(_data_grid);
            }
            else if (selected == "2")
            {
                logs.setLogger(_txt_box);
                flowLayoutPanel1.Controls.Add(_txt_box);
            }
        }
    }
}
