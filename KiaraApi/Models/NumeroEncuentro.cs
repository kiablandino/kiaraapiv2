using System.ComponentModel.DataAnnotations;

namespace CUR.Api.Models
{
    public class NumeroEncuentro
    {
        [Key]
        public int NumeroEncuentroId { get; set; }

        [Required]
        public int Valor { get; set; }  
    }
}
