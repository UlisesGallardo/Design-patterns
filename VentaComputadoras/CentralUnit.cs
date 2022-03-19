using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaComputadoras
{
    class CentralUnit: Component
    {
        string centralunit = "Central Unit Mac: CPU,Motherboard,Ram,Disk";
        public void setManufacturer(string manufacturer)
        {
            _fabricante = manufacturer;
        }

        public void setPrice(float price)
        {
            _preico = price;
        }

        public void setModel(string model)
        {
            _modelo = model;
        }

        public void setTypeComponent(string type)
        {
            _typeComponent = type;
        }


        public override string ToString() =>
        $"{this.centralunit} - {this._fabricante}";
    }
}
