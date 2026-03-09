using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Domain.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public Producto Producto { get; set; }
    }
}
