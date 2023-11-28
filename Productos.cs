using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Productos
    {
        public string nombreProductos { get; set; }
        public string Descripcion { get; set; }
        public string PrecioVenta { get; set; }
        public int añosDuracion { get; set; }

        public Productos(string nombreProductos, string descripcion, string precioVenta, int añosDuracion)
        {
            this.nombreProductos = nombreProductos;
            Descripcion = descripcion;
            PrecioVenta = precioVenta;
            this.añosDuracion = añosDuracion;
        }
    }
}
