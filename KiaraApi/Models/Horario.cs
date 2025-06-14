using System.ComponentModel.DataAnnotations;

namespace CUR.Api.Models
{
    public class Horario
    {
        [Key]
        public int HorarioId { get; set; }

        [Required]
        public int AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }

        public int? AulaId { get; set; }
        public Aula Aula { get; set; }

        public int? LaboratorioId { get; set; }
        public Laboratorio Laboratorio { get; set; }

        [Required]
        public int DocenteId { get; set; }
        public Docente Docente { get; set; }

        [Required, StringLength(20)]
        public string Dia { get; set; }   // e.g. "Lunes", "Martes"

        [Required, StringLength(20)]
        public string Hora { get; set; }  // e.g. "08:00-10:00"
    }
}
