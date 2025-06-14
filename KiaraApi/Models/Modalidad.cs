using System.ComponentModel.DataAnnotations;

namespace CUR.Api.Models
{
    public class Modalidad
    {
        [Key]
        public int ModalidadId { get; set; }

        [Required, StringLength(50)]
        public string Tipo { get; set; }  // e.g. "SabatinoEncuentro","RegularLunVie",etc.
    }
}
