using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tienda.Application.DTOs
{
    public class CreateRolDto
    {
        [Required(ErrorMessage = "El nombre del rol es obligatorio")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
