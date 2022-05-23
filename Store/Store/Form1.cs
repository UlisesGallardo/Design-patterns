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
                /*
                Tienda t = new Tienda();
                t.NombreTienda = "Tienda05";
                t.ID_Tienda = "05";

                List<Producto> l = new List<Producto>();
                Producto p1 = new Producto();
                p1.Cantidad = "5";
                p1.ID_Producto = "01";
                p1.NombreProducto = "Bebidas alcoholicas";
                l.Add(p1);
                Producto p2 = new Producto();
                p2.Cantidad = "20";
                p2.ID_Producto = "02";
                p2.NombreProducto = "Lacteos";
                t.Productos = l;
                l.Add(p2);
                Producto p3 = new Producto();
                p3.Cantidad = "45";
                p3.ID_Producto = "03";
                p3.NombreProducto = "Higiene personal";
                l.Add(p3);
                Producto p4 = new Producto();
                p4.Cantidad = "64";
                p4.ID_Producto = "04";
                p4.NombreProducto = "Congelados";
                l.Add(p4);
                t.Productos = l;*/
                /*
                QR qr = new QR();
                qr.Create(t);
                qr.Save(Directory.GetCurrentDirectory() + "\\img05.png");
                string s = qr.Read(Directory.GetCurrentDirectory() + "\\img05.png");
                Console.WriteLine(s);*/
                GenerateDynamicUserControl(); 
        }

        private void GenerateDynamicUserControl()
        {
            string[] allfiles = Directory.GetFiles(Directory.GetCurrentDirectory()+"\\Pedidos", "*.*", SearchOption.AllDirectories);
            int NTiendas = allfiles.Length;

            flowLayoutPanel1.Controls.Clear();
            Pedidos[] items = new Pedidos[NTiendas];
            _2DCodeAdapter adapter_to_QR = new _2DCodeAdapter("QR");

            Dictionary<string, int> resumen_total = new Dictionary<string, int>();
            Dictionary<string, int> beneficio_tienda = new Dictionary<string, int>();

            for (int i = 0; i < items.Length; i++)
            {
                string str = adapter_to_QR.Read2dCode(allfiles[i]);
                JObject json = JObject.Parse(str);
                Tienda album = json.ToObject<Tienda>();

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
                if(beneficio_tienda.ContainsKey(album.NombreTienda) == false) beneficio_tienda.Add(album.NombreTienda, CantidadTotal);

                items[i].Productos = lista;
                items[i].Imagen = new Bitmap(allfiles[i]);
                flowLayoutPanel1.Controls.Add(items[i]);
            }
            _dt = DataTableResumen(resumen_total);
        }


        public DataTable DataTableResumen(Dictionary<string, int> resumen_total)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Producto", typeof(string)));
            dt.Columns.Add(new DataColumn("Cantidad", typeof(int)));
            dt.Columns.Add(new DataColumn("Capacidad", typeof(int)));
            dt.Columns.Add(new DataColumn("CantidadCamiones", typeof(int)));
            dt.Columns.Add(new DataColumn("Mínimos Necesarios", typeof(int)));

            DataRow dr = null;

            foreach (KeyValuePair<string, int> kvp in resumen_total)
            {
                dr = dt.NewRow();
                dr["Producto"] = kvp.Key;
                dr["Cantidad"] = kvp.Value;
                dr["Capacidad"] = 120;
                dr["CantidadCamiones"] = 5;
                double d  = Convert.ToDouble(kvp.Value) / Convert.ToDouble(120);
                dr["Mínimos Necesarios"] = (int)Math.Ceiling(d);
                dt.Rows.Add(dr);
            }
            return dt;
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
            ResumenPedidos resumen_pedidos = new ResumenPedidos();
            this.Hide();
            resumen_pedidos.dt = _dt;
            resumen_pedidos.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarPedido agregar_pedidos = new AgregarPedido();
            this.Hide();
            agregar_pedidos.previus = "general";
            agregar_pedidos.Show();
        }
    }
}