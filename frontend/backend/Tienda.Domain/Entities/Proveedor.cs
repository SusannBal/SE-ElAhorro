using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Domain.Entities
{
    public  class Proveedor
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Relacion { get; set; }

        public ICollection<ProductoProveedor> ProductoProveedores { get; set; }
    }
}
