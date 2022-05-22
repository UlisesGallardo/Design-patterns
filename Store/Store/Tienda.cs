using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Tienda
    {
        public string NombreTienda { get; set; }
        public string ID_Tienda { get; set; }
        public List<Producto> Productos { get; set; }
    }
    public class Producto
    {
        public string NombreProducto { get; set; }
        public string ID_Producto { get; set; }
        public string Cantidad { get; set; }
    }
}
