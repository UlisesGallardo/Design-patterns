using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface InformationDissemination
    {
        public Bitmap Create(string data);

        public string Read(string path);

        public void Save(string path); 
    }
}
