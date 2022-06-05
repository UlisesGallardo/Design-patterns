using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class Form1 : Form
    {
        public System.Data.DataTable _dt { get; set; }
        public System.Data.DataTable _dtCamiones {get;set;}
        public List<Tienda> tiendas;
        public List<Bitmap> _imagenes;
        public Dictionary<Tienda, int> beneficio_tienda;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInformation();
        }

        public void LoadInformation()
        {
                GenerateDynamicUserControl(); 
        }

        private void GenerateDynamicUserControl()
        {
            string[] allfiles = Directory.GetFiles(Directory.GetCurrentDirectory()+"\\Pedidos", "*.*", SearchOption.AllDirectories);
            int NTiendas = allfiles.Length;

            flowLayoutPanel1.Controls.Clear();
            Pedidos[] items = new Pedidos[NTiendas];
            StoreTo2Dcode adapter_to_QR = new _2DCodeAdapter("QR");

            Dictionary<string, int> resumen_total = new Dictionary<string, int>();
            tiendas = new List<Tienda>();
            _imagenes = new List<Bitmap>();
            beneficio_tienda = new Dictionary<Tienda, int>();
            for (int i = 0; i < items.Length; i++)
            {
                Tienda album = adapter_to_QR.TwoDImageCodeToStore(allfiles[i]);
                tiendas.Add(album);

                items[i] = new Pedidos();
                items[i].NombreTienda = album.NombreTienda;
                List<string> lista = new List<string>();
                int CantidadTotal = 0;

                for (int j=0; j<album.Productos.Count; j++)
                {
                    string valores = (j+1).ToString( ) +".- " + album.Productos[j].NombreProducto + " - " + album.Productos[j].Cantidad;
                    string name = album.Productos[j].NombreProducto;
                    int cantidad = Int32.Parse(album.Productos[j].Cantidad);
                    if (resumen_total.ContainsKey(name) == true) resumen_total[name] += cantidad;
                    else resumen_total.Add(name, cantidad);
                    CantidadTotal += cantidad;

                    lista.Add(valores);
                }
                if(beneficio_tienda.ContainsKey(album) == false) beneficio_tienda.Add(album, CantidadTotal);

                items[i].Productos = lista;

                Image imagen;
                using (var bmpTemp = new Bitmap(allfiles[i]))
                {
                    imagen = new Bitmap(bmpTemp);
                }

                _imagenes.Add(imagen as Bitmap);
                items[i].Imagen = imagen as Bitmap;
                flowLayoutPanel1.Controls.Add(items[i]);
            }
            _dt = DataTableResumen(resumen_total);
            _dtCamiones = DataTableCamiones(resumen_total);

        }


        public DataTable DataTableResumen(Dictionary<string, int> resumen_total)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Producto", typeof(string)));
            dt.Columns.Add(new DataColumn("Cantidad", typeof(int)));
            DataRow dr = null;

            foreach (KeyValuePair<string, int> kvp in resumen_total)
            {
                dr = dt.NewRow();
                dr["Producto"] = kvp.Key;
                dr["Cantidad"] = kvp.Value;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public DataTable DataTableCamiones(Dictionary<string, int> resumen_total)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("Capacidad", typeof(int)));
            dt2.Columns.Add(new DataColumn("CantidadCamiones", typeof(int)));
            dt2.Columns.Add(new DataColumn("Necesarios", typeof(int)));

            DataRow dr = null;

            foreach (KeyValuePair<string, int> kvp in resumen_total)
            {
                dr = dt2.NewRow();
                int capacity = 100;
                dr["Capacidad"] = capacity;
                dr["CantidadCamiones"] = 2;
                double d = Convert.ToDouble(kvp.Value) / Convert.ToDouble(capacity);
                dr["Necesarios"] = (int)Math.Ceiling(d);
                dt2.Rows.Add(dr);
            }
            return dt2;
        }

        public class RootObject
        {
            public List<Tienda> tienda { get; set; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            flowLayoutPanel1.Controls.Clear();

            ResumenPedidos resumen_pedidos = new ResumenPedidos();
            resumen_pedidos.dt = _dt;
            resumen_pedidos.Camiones = _dtCamiones;
            resumen_pedidos.Tiendas = tiendas;
            resumen_pedidos.Imagenes = _imagenes;
            resumen_pedidos.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearPedido agregar_pedidos = new CrearPedido();
            this.Hide();
            agregar_pedidos.previous = "general";
            agregar_pedidos.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WriteLogs logs = WriteLogs.GetInstance();
            logs.Show();
        }
    }
}