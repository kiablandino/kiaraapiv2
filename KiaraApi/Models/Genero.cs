using System.ComponentModel.DataAnnotations;

namespace CUR.Api.Models
{
    public class Genero
    {
        [Key]
        public int GeneroId { get; set; }

        [Required, StringLength(20)]
        public string Nombre { get; set; }  // e.g. "Masculino","Femenino"
    }
}
