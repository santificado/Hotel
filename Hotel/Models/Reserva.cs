using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    [Table("TB_RESERVA")]
    public class Reserva
    {
        [Key]
        public int ReservaID { get; set; }

        [Required]
        public DateTime DataEntrada { get; set;}
        
        [Required]  
        public DateTime DataSaida { get; set; }

        [Required]
        public decimal ValorTotal { get; set; }         
        
        public virtual ICollection<Hospede> Hospedes { get; set; }

        public virtual ICollection<Quarto> Quartos { get; set; }

    }
}
