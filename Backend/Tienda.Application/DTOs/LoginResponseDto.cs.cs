using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Application.DTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string Rol { get; set; }
        public string Nombre { get; set; }
    }
}
