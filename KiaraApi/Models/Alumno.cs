using System.ComponentModel.DataAnnotations;

namespace CUR.Api.Models
{
    public class Alumno
    {
        [Key]
        public int AlumnoId { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }

        [Required]
        public int DireccionId { get; set; }
        public Direccion Direccion { get; set; }

        [Required]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }

        [Required]
        public int NumeroEncuentroId { get; set; }
        public NumeroEncuentro NumeroEncuentro { get; set; }
    }
}
