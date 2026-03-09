using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Domain.Entities
{
    public class ProductoProveedor
    {
        public int Id { get; set; }

        public int IdProducto { get; set; }

        public int IdProveedor { get; set; }

        public string Detalle { get; set; }

        public string Estado { get; set; }

        public Producto Producto { get; set; }

        public Proveedor Proveedor { get; set; }
    }
}
