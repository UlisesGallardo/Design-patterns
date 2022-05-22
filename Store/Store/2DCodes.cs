using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface _2DCodes
    {
        public Bitmap Create2dCode(Tienda tienda);
        public string Read2dCode(string path);
        public void Save2dCode(string path);
    }
}
