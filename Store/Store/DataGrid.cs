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
    public partial class DataGrid : UserControl, Binnacle
    {
        public System.Data.DataTable dt { get; set; }

        public DataGrid()
        {
            InitializeComponent();
        }

        public void Write(string text)
        {
            DataRow dr = dt.NewRow();
            dr["Evento"] = text;
            dr["Fecha"] = DateTime.Now.ToString();
            dt.Rows.Add(dr);
            guna2DataGridView1.DataSource = dt;
        }

        private void DataGrid_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Evento", typeof(string)));
            dt.Columns.Add(new DataColumn("Fecha", typeof(string)));
            guna2DataGridView1.DataSource = dt;
        }
    }
}
