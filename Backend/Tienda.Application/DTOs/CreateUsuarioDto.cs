using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tienda.Application.DTOs
{
    public class CreateUsuarioDto
    {
        [Required]
        [MinLength(3)]
        public string Nombre { get; set; }

        [Required]
        [MinLength(4)]
        public string Usuario { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [MinLength(6)]
        public string Contrasena { get; set; }

        [Required]
        public int IdRol { get; set; }

    }
}
