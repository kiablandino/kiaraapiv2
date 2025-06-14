using System.ComponentModel.DataAnnotations;

namespace CUR.Api.Models
{
    public class TipoDocente
    {
        [Key]
        public int TipoDocenteId { get; set; }

        [Required, StringLength(50)]
        public string Descripcion { get; set; }  
    }
}
