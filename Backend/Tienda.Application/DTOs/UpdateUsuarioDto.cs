using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tienda.Application.DTOs
{
    public class UpdateUsuarioDto
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public int IdRol { get; set; }

        public string Estado { get; set; }
        
        public bool? Bloqueado { get; set; }
        public int? IntentosFallidos { get; set; }
    }
}
