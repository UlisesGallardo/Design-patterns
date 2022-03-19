using System;

namespace VentaComputadoras
{
    abstract class PeripheralsCreator
    {
        public abstract Component CreatePeripheral(int code);
    }
}
