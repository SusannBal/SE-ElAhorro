using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Application.DTOs
{
    public class UsuarioResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
        public bool Bloqueado { get; set; }
        public int IntentosFallidos { get; set; }
    }
}
