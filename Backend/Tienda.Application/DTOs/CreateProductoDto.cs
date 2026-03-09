using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tienda.Application.DTOs
{
    public class CreateProductoDto
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Codigo { get; set; }

        public DateTime? Fecha_Vencimiento { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }
    }
}
