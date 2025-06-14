using System.ComponentModel.DataAnnotations;

namespace CUR.Api.Models
{
    public class Laboratorio
    {
        [Key]
        public int LaboratorioId { get; set; }

        [Required, StringLength(50)]
        public string Nombre { get; set; }
    }
}
