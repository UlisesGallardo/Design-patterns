using System;

namespace VentaComputadoras
{
    public class Component
    {
       
        protected string _name { get; set; }
        protected string _fabricante { get; set; }
        protected string _modelo { get; set; }
        protected float _preico { get; set; }

        protected string _typeComponent { get; set; }

        public void Modify(string name, string model)
        {
            this._name = name;
            this._modelo = model;
        }

        public string GetTypeComponent()
        {
            return _typeComponent;
        }

        public float GetPrice()
        {
            return _preico;
        }

        public override string ToString() =>
        $"{this._name} - {this._fabricante} - {this._preico}";
    }
}
