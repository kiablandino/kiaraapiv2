using System.ComponentModel.DataAnnotations;

namespace CUR.Api.Models
{
    public class Docente
    {
        [Key]
        public int DocenteId { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int TipoDocenteId { get; set; }
        public TipoDocente TipoDocente { get; set; }

        [Required]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
