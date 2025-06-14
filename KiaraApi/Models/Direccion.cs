using System.ComponentModel.DataAnnotations;

namespace CUR.Api.Models
{
    public class Direccion
    {
        [Key]
        public int DireccionId { get; set; }

        [Required, StringLength(200)]
        public string Calle { get; set; }

        [Required]
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
    }
}
