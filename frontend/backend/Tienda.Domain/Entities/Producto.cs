using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Domain.Entities
{
    public class Producto
    {

        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public string Codigo { get; set; }

        public DateTime? Fecha_Vencimiento { get; set; }

        public decimal Precio { get; set; }

        public string Estado { get; set; }

        public Stock Stock { get; set; }

        public ICollection<DetalleVenta> DetallesVenta { get; set; }

        public ICollection<ProductoProveedor> ProductoProveedores { get; set; }
    }
}
