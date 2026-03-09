using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Domain.Entities
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }

        public int IdVenta { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public decimal SubTotal { get; set; }

        public Venta Venta { get; set; }

        public Producto Producto { get; set; }
    }
}
