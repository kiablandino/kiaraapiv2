using System.ComponentModel.DataAnnotations;

namespace CUR.Api.Models
{
    public class Asignatura
    {
        [Key]
        public int AsignaturaId { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int PlanEstudioId { get; set; }
        public PlanEstudio PlanEstudio { get; set; }

        [Required]
        public int ModalidadId { get; set; }
        public Modalidad Modalidad { get; set; }
    }
}
