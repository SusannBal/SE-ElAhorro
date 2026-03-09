using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tienda.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Column("Usuario")]
        public string Username { get; set; }

        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public int IdRol { get; set; }
        public string Estado { get; set; }
        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }

        public Rol Rol { get; set; }
    }
}
