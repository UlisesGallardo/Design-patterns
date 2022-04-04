using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALUMNI_APP
{
    public partial class BasicInformation : UserControl
    {
        public List<string> info;
        public List<string> NamesRows;
        public BasicInformation()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Updating viewtable with list information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BasicInformation_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Information"));
            dt.Columns.Add(new DataColumn("Values"));
            DataRow dr = null;

            var res = NamesRows.Zip(info, (n, w) => new { Prop = n, Value = w });
            foreach (var a in res)
            {
                dr = dt.NewRow();
                dr["Information"] = a.Prop;
                dr["Values"] = a.Value;
                dt.Rows.Add(dr);
            }
            gridBasicInformation.DataSource = dt;
            gridBasicInformation.ColumnHeadersHeight = 40;
            //gridBasicInformation.Columns.Add("Column", "Props");
            //gridBasicInformation.DataSource = NamesRows.Select(x => new { Props = x }).ToList();
            //gridBasicInformation.DataSource = info.Select(x => new { Value = x }).ToList();
        }
    }
}
