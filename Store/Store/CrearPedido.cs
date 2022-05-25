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
    public partial class CrearPedido : Form
    {

        public string previous { get; set; }

        public CrearPedido()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CrearPedido_Load(object sender, EventArgs e)
        {
            NuevoPedido _nuevo = new NuevoPedido();
            _nuevo.previous = previous;
            flowLayoutPanel1.Controls.Add(_nuevo);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 anterior = new Form1();
            this.Close();
            anterior.Show();
        }
    }
}
