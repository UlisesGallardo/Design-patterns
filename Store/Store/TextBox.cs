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
    public partial class TextBox : UserControl, Binnacle
    {
        public TextBox()
        {
            InitializeComponent();
        }

        public void Write(string text)
        {
            
            textBox1.AppendText(text+" -> Fecha: " + DateTime.Now.ToString() + "\r\n");
        }

        private void TextBox_Load(object sender, EventArgs e)
        {

        }
    }
}
