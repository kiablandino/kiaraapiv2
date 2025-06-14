using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CUR.Api.Models
{
    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        // Relación 1-N con Carrera
        public ICollection<Carrera> Carreras { get; set; }
    }
}
