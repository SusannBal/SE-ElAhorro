using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Domain.Entities
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
