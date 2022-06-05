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

        List<KeyValuePair<Tienda, Bitmap>> _lista_ordenada;

        private int Comparar(KeyValuePair<Tienda, Bitmap> x, KeyValuePair<Tienda, Bitmap> y) 
        {
            int sum1 = 0, sum2 = 0;
            foreach (Producto p in x.Key.Productos)
            {
                sum1 += Int32.Parse(p.Cantidad);
            }
            foreach (Producto p in y.Key.Productos)
            {
                sum2 += Int32.Parse(p.Cantidad);
            }
            if (sum1 == sum2) return 0;
            if (sum1 > sum2) return -1;
            return 1;
        }


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
            _lista_ordenada = new List<KeyValuePair<Tienda, Bitmap>>();
            for (int i = 0; i < NTiendas; i++)
            {
                Image img;
                using (var bmpTemp = new Bitmap(allfiles[i]))
                {
                    img = new Bitmap(bmpTemp);
                }
                _2DCodeAdapter adapter_to_QR = new _2DCodeAdapter("QR");
                Tienda album = adapter_to_QR.TwoDImageCodeToStore(allfiles[i]);
                _lista_ordenada.Add(new KeyValuePair<Tienda, Bitmap>(album, img as Bitmap));
            }
            _lista_ordenada.Sort(Comparar);
            UpdateData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(index-1>=0)index--;
            button1.Text = "Siguiente";
            UpdateData();
        }

        private void SurtirPedido_Load(object sender, EventArgs e)
        {
            _lista_ordenada = new List<KeyValuePair<Tienda, Bitmap>>();
            for (int i=0; i<_tiendas.Count; i++)
            {
                _lista_ordenada.Add(new KeyValuePair<Tienda, Bitmap>(_tiendas[i], _imagenes[i]));
            }
            _lista_ordenada.Sort(Comparar);
            index = 0;
            if(_tiendas.Count ==1) button1.Text = "Finalizar";
            UpdateData();
        }

        public void UpdateData()
        {
            flowLayoutPanel1.Controls.Clear();
            NuevoPedido _nuevo = new NuevoPedido();
            _nuevo.previous = "surtir";
            _nuevo.NuevaTienda = _lista_ordenada[index].Key;
            NombreTienda.Text  = _lista_ordenada[index].Key.NombreTienda;
            ImagenInfo.Image = _lista_ordenada[index].Value;
            flowLayoutPanel1.Controls.Add(_nuevo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index == _lista_ordenada.Count -1) finalizar();
            if (index+1< _lista_ordenada.Count)index++;
            if (index == _lista_ordenada.Count - 1) button1.Text = "Finalizar"; 
            UpdateData();
        }

        public void finalizar()
        {
            foreach (Form forms in Application.OpenForms)
            {
                string name = forms.Name;
                if (name == "WriteLogs")
                {
                    WriteLogs form = (WriteLogs)Application.OpenForms["WriteLogs"];
                    form.logs.execute("Pedidos Surtidos ");
                    break;
                }
            }

            Form1 pedido = new Form1();
            this.Close();
            pedido.Show();
        }
    }
}
