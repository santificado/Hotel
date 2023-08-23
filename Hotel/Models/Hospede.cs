using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    [Table("TB_HOSPEDE")]
    public class Hospede
    { 
        [Key]
        public int HospedeID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set;}

        [EmailAddress] 
        public string Email { get; set; }
        
        
        [Phone]
        public string telefone { get; set;}

        public virtual ICollection<Reserva> Reservas { get; set; }

    }
}
