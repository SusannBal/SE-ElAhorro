using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tienda.Application.DTOs
{
    public class CreateVentaDto
    {
        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "La venta debe tener al menos un producto")]
        public List<CreateDetalleVentaDto> Detalles { get; set; }
    }
}
