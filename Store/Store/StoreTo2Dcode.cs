using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface StoreTo2Dcode
    {
        public Bitmap Convert(Tienda tienda);
        public Tienda TwoDImageCodeToStore(string path);
        public void Save2dCode(string path);
    }
}
