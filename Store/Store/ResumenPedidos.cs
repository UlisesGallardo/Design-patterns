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
        public System.Data.DataTable _dtCamiones { get; set; }

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

        public DataTable Camiones
        {
            set
            {
                _dtCamiones = new DataTable();
                _dtCamiones = value;
            }
        }


        public ResumenPedidos()
        {
            InitializeComponent();
        }

        private void ResumenPedidos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = _dtCamiones;

            foreach (Form forms in Application.OpenForms)
            {
                string name = forms.Name;
                if(name == "WriteLogs")
                {
                    WriteLogs form = (WriteLogs)Application.OpenForms["WriteLogs"];
                    form.logs.execute("Comienzo de simulación ");
                    break;
                }
            }
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
            
            DataTable table = (dataGridView1.DataSource as DataTable).Copy();
            DataTable table2 = (dataGridView2.DataSource as DataTable).Copy();

            foreach (Form forms in Application.OpenForms)
            {
                string name = forms.Name;
                if (name == "WriteLogs")
                {
                    WriteLogs form = (WriteLogs)Application.OpenForms["WriteLogs"];
                    form.logs.execute("Camiones Agregados ");
                    break;
                }
            }

            int index = 0;
            foreach (DataRow row in table2.Rows)
            {
                int cantidad = Int32.Parse(table.Rows[index]["Cantidad"].ToString());
                int capacidad = Int32.Parse(row["Capacidad"].ToString());
                int cantidadCamiones = Int32.Parse(row["CantidadCamiones"].ToString());

                if (cantidadCamiones * capacidad < cantidad)
                {
                    PassSimulation = false;
                    break;
                }
                sobrante += (cantidadCamiones * capacidad - cantidad);
                index++;
            }


            if (PassSimulation)
            {
                DialogResult dialogResult = MessageBox.Show("La simulación ha tenido éxito.\nCantidad de producto sobrante: "+sobrante.ToString()+ " productos.\n¿Desea continuar con el surtido de productos?", "Simulación Exitosa.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (Form forms in Application.OpenForms)
                    {
                        string name = forms.Name;
                        if (name == "WriteLogs")
                        {
                            WriteLogs form = (WriteLogs)Application.OpenForms["WriteLogs"];
                            form.logs.execute("Fin de simulación ");
                            break;
                        }
                    }

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

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 anterior = new Form1();
            this.Close();
            anterior.Show();
        }
    }
}
