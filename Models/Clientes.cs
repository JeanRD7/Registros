using System.ComponentModel.DataAnnotations;

namespace Registros.Models
{
    public class Clientes
    {
        [Key]

        public int ClientesId { get; set; }
        [Required (ErrorMessage = "El nombre del cliente es obligatorio")]
        public string? Nombre { get; set; }

        [Required (ErrorMessage ="El Telegono del cliente es obligatorio")]
        public string? Telefono { get; set; }

        [Required (ErrorMessage ="El Celular del cliente es obligatoria")]
        public string? Celular { get; set; }

        [Required (ErrorMessage ="El RNC del cliente es obligatorio")]
        public string? Rnc { get; set; }

        [Required (ErrorMessage ="El Email del cliente es obligatorio")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "La Direccion del cliente es obligatorio")]
        public string? Direccion { get; set; }
    }
}
