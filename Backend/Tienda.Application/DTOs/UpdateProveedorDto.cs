using System.ComponentModel.DataAnnotations;

namespace Tienda.Application.DTOs
{
    public class UpdateProveedorDto
    {
        [Required(ErrorMessage = "El nombre del proveedor es obligatorio")]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(20)]
        public string Telefono { get; set; }

        [MaxLength(100)]
        public string Relacion { get; set; }
    }
}