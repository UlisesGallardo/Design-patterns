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
    public partial class ResumenPedidos : Form
    {
        public System.Data.DataTable dt { get; set; }
        List<Tienda> _tiendas;
        List<Bitmap> _imagenes;


        public List<Tienda> Tiendas
        {
            set
            {
                _tiendas = new List<Tienda>();
                _tiendas = value;
            }
        }

        public List<Bitmap> Imagenes
        {
            set
            {
                _imagenes = new List<Bitmap>();
                _imagenes = value;
            }
        }


        public ResumenPedidos()
        {
            InitializeComponent();
        }

        private void ResumenPedidos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool PassSimulation = true;
            int sobrante = 0;

            DataTable table = dataGridView1.DataSource as DataTable;
            foreach (DataRow row in table.Rows)
            {

                string name = row["Producto"].ToString();
                int cantidad = Int32.Parse(row["Cantidad"].ToString());
                int capacidad = Int32.Parse(row["Capacidad"].ToString());
                int cantidadCamiones = Int32.Parse(row["CantidadCamiones"].ToString());

                if (cantidadCamiones * capacidad < capacidad)
                {
                    PassSimulation = false;
                    break;
                }
                sobrante += (cantidadCamiones * capacidad - cantidad);
            }


            if (PassSimulation)
            {
                DialogResult dialogResult = MessageBox.Show("La simulación ha tenido éxito.\nCantidad de producto sobrante: "+sobrante.ToString()+ " productos.\n¿Desea continuar con el surtido de productos?", "Simulación Exitosa.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    SurtirPedido pedido = new SurtirPedido();
                    pedido.Tiendas = _tiendas;
                    pedido.Imagenes = _imagenes;
                    this.Close();
                    pedido.Show();
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("No se cumple con la demanda de producto.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
