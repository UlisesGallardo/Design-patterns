using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class AgregarPedido : Form
    {
        public System.Data.DataTable dt { get; set; }
        public string previus  { get; set; }

        public List<Producto> _lista_productos;

    public AgregarPedido()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (NombreProducto.Text.Length<=0)
            {
                DialogResult dialogResult = MessageBox.Show("El nombre del producto está vacío.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Producto p = new Producto();
            
            p.ID_Producto = (dt.Rows.Count + 1).ToString();
            p.NombreProducto = NombreProducto.Text;
            p.Cantidad = numericUpDown1.Value.ToString();
            _lista_productos.Add(p);

            DataRow dr = dt.NewRow();
            dr["ID"] = dt.Rows.Count+1;
            dr["Producto"] = NombreProducto.Text;
            dr["Cantidad"] = numericUpDown1.Value;
            dt.Rows.Add(dr);

        }

        private void NombreTienda_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AgregarPedido_Load(object sender, EventArgs e)
        {
            _lista_productos = new List<Producto>();
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Producto", typeof(string)));
            dt.Columns.Add(new DataColumn("Cantidad", typeof(int)));

            dataGridView1.DataSource = dt;
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "dataGridViewDeleteButton";
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteButton);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_lista_productos.Count <=0)
            {
                DialogResult dialogResult = MessageBox.Show("No se ha agregado ningun producto.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nombreTienda01.Text.Length<=0)
            {
                DialogResult dialogResult = MessageBox.Show("El nombre de la tienda está vacío.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Tienda t = new Tienda();

            t.NombreTienda = nombreTienda01.Text;
            t.Productos = _lista_productos;

            string[] allfiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Pedidos", "*.*", SearchOption.AllDirectories);
            string NTiendas = (allfiles.Length+1).ToString();
            t.ID_Tienda = NTiendas;

            _2DCodeAdapter adapter_to_QR = new _2DCodeAdapter("QR");
            adapter_to_QR.Create2dCode(t);
            adapter_to_QR.Save2dCode(Directory.GetCurrentDirectory() + "\\Pedidos\\img0" + NTiendas+".png");


            if (previus == "general")
            {
                Form1 guardar = new Form1();
                this.Hide();
                guardar.Show();
            }
            else
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
                    return;

                if (e.ColumnIndex == dataGridView1.Columns["dataGridViewDeleteButton"].Index)
                {
                    _lista_productos.RemoveAt(e.RowIndex);
                    dt.Rows.RemoveAt(e.RowIndex);
                    Console.WriteLine(e.RowIndex);
                    
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (previus == "general")
            {
                Form1 guardar = new Form1();
                this.Hide();
                guardar.Show();
            }
        }
    }
}
