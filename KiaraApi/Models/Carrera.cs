using System.ComponentModel.DataAnnotations;

namespace CUR.Api.Models
{
    public class Carrera
    {
        [Key]
        public int CarreraId { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        [Required]
        public int PlanEstudioId { get; set; }
        public PlanEstudio PlanEstudio { get; set; }
    }
}
