using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaComputadoras
{
    class Printer : Component, Peripheral
    {
        public string Connector { get; set; }

        public int[] Puertos { get; set; }

        public string TypePeripheral { get; set; }

        public string Toner = "";
        public string PrinterType = "";

        public void setName(string name)
        {
            _name = name;
        }

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
        $"{this._name} - {this._fabricante}";
    }
}
