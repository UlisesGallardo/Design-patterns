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

            for (int i = 0; i < items.Length; i++)
            {
                string str = adapter_to_QR.Read2dCode(allfiles[i]);
                JObject json = JObject.Parse(str);
                Tienda album = json.ToObject<Tienda>();

                items[i] = new Pedidos();
                items[i].NombreTienda = album.NombreTienda;
                List<string> lista = new List<string>();

                for (int j=0; j<album.Productos.Count; j++)
                {
                    string valores = (j+1).ToString( ) +".- " + album.Productos[j].NombreProducto + " - " + album.Productos[j].Cantidad;
                    lista.Add(valores);
                }
                items[i].Productos = lista;
                items[i].Imagen = new Bitmap(allfiles[i]);
                flowLayoutPanel1.Controls.Add(items[i]);
            }
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

           
    }
}