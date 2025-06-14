using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CUR.Api.Models
{
    public class PlanEstudio
    {
        [Key]
        public int PlanEstudioId { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        public ICollection<Asignatura> Asignaturas { get; set; }
    }
}
