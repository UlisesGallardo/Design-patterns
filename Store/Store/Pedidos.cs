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
    public partial class Pedidos : UserControl
    {
        public Pedidos()
        {
            InitializeComponent();
        }

        private string _nombre_tienda;
        private List<string> _productos;
        private Bitmap _imagen;

        public string NombreTienda
        {
            get { return _nombre_tienda; }
            set { _nombre_tienda = value; NTienda.Text = value;}
        }   

        public List<string> Productos
        {
            get { return _productos; }
            set { 
                _productos = value; 
                for(int i=0; i<value.Count; i++)
                {
                    ListaProductos.Items.Add(value[i]);
                }
            }
        }

        public Bitmap Imagen
        {
            set { _imagen = value; pictureBox1.Image = value; }
            get { return _imagen; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Pedidos_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
