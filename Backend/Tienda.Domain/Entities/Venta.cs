using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Domain.Entities
{
    public class Venta
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public DateTime Fecha_Compra { get; set; }

        public decimal Total { get; set; }

        public string Estado { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<DetalleVenta> Detalles { get; set; }
    }
}
