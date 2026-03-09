using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tienda.Application.DTOs
{
    public class UpdateProductoDto
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public DateTime? Fecha_Vencimiento { get; set; }

        public string Estado { get; set; }
    }
}
