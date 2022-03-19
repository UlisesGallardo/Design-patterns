using System;
using System.Collections.Generic;

namespace VentaComputadoras
{
    class Computer
    {
        private Dictionary<Component, Component> _parts = new Dictionary<Component, Component>();
        public void AddComponent(Component part)
        {
            _parts.Add(part, part);
        }

        public Dictionary<Component, Component> ShowComponents()
        {
            return _parts;
        }

        public void SetComponents(Dictionary<Component, Component> components)
        {
            //Importante validar los nuevos componentes!!
            _parts = components;
        }

        public override string ToString()
        {
            float total = 0;
            foreach(KeyValuePair<Component, Component> entry in _parts)
            {
                total += entry.Value.GetPrice();
            }
            return String.Join("\n", _parts.Values) + "\nTotal Price -> "+ (total).ToString();
        }
    }
}
