using Newtonsoft.Json.Linq;
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
    public partial class SurtirPedido : Form
    {
        List<Tienda> _tiendas;
        List<Bitmap> _imagenes;


        public int index;
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
        public SurtirPedido()
        {
            InitializeComponent();
           
        }

        public void UpdateImages()
        {
            string[] allfiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Pedidos", "*.*", SearchOption.AllDirectories);
            int NTiendas = allfiles.Length;
            _imagenes = new List<Bitmap>();
            _tiendas = new List<Tienda>();
            for (int i = 0; i < NTiendas; i++)
            {
                Image img;
                using (var bmpTemp = new Bitmap(allfiles[i]))
                {
                    img = new Bitmap(bmpTemp);   
                }
                _2DCodeAdapter adapter_to_QR = new _2DCodeAdapter("QR");
                string str = adapter_to_QR.Read2dCode(allfiles[i]);
                JObject json = JObject.Parse(str);
                Tienda album = json.ToObject<Tienda>();
                _imagenes.Add(img as Bitmap);
                _tiendas.Add(album);
            }
            
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index--;
            Update();
        }

        private void SurtirPedido_Load(object sender, EventArgs e)
        {
           
            index = 0;
            Update();
        }

        public void Update()
        {
            flowLayoutPanel1.Controls.Clear();
            NuevoPedido _nuevo = new NuevoPedido();
            _nuevo.previous = "surtir";
            _nuevo.NuevaTienda = _tiendas[index];
            NombreTienda.Text = _tiendas[index].NombreTienda;
            ImagenInfo.Image = _imagenes[index];
           flowLayoutPanel1.Controls.Add(_nuevo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index++;
            Update();
        }
    }
}
