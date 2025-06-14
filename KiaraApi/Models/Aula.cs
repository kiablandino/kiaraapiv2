using System.ComponentModel.DataAnnotations;

namespace CUR.Api.Models
{
    public class Aula
    {
        [Key]
        public int AulaId { get; set; }

        [Required, StringLength(50)]
        public string Codigo { get; set; }
    }
}
