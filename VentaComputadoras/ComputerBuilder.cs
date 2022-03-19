using System;
using System.Collections.Generic;

namespace VentaComputadoras
{
    abstract class ComputerBuilder
    {
        public abstract void BuildPeripheral();
        public abstract void CentralUnit();

        public abstract void ModifyPeripheral(Dictionary<Component, Component> new_components);

        public abstract void BuildSpecificPeripheral(int code);

        public abstract Dictionary<Component, Component> ShowComponents();

        public abstract Computer GetComputer();
    }
}
