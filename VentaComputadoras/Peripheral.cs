using System;

namespace VentaComputadoras
{
    interface Peripheral
    {
        string Connector { get; set; }

        int [] Puertos { get; set; }

        string TypePeripheral { get; set; }
    }
}
