using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class _2DCodeAdapter : _2DCodes
    {
        InformationDissemination _i_d;

        public _2DCodeAdapter(string TwoDCodeType)
        {
            if (TwoDCodeType == "QR") _i_d = new QR();
            else _i_d  = null;
        }

        public Bitmap Create2dCode(Tienda tienda) {
            if (_i_d == null) return null;
            return _i_d.Create(tienda);
        }
        public string Read2dCode(string path)
        {
            if (_i_d == null) return null;
            return _i_d.Read(path);
        }
        public void Save2dCode(string path)
        {
            if (_i_d != null) _i_d.Save(path);
        }
    }
}
