using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class _2DCodeAdapter : StoreTo2Dcode
    {
        InformationDissemination _i_d;

        public _2DCodeAdapter(string TwoDCodeType)
        {
            if (TwoDCodeType == "QR") _i_d = new QR();
            else _i_d  = null;
        }

        public Bitmap Convert(Tienda tienda) {
            string data = System.Text.Json.JsonSerializer.Serialize(tienda);

            if (_i_d == null) return null;
            return  _i_d.Create(data); 
        }
        public Tienda TwoDImageCodeToStore(string path)
        {
            string str = _i_d.Read(path);
            JObject json = JObject.Parse(str);
            Tienda t = json.ToObject<Tienda>();
            if (_i_d == null) return null;
            return t;
        }
        public void Save2dCode(string path)
        {
            if (_i_d != null) _i_d.Save(path);
        }
    }
}
