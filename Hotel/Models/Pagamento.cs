using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    [Table("TB_PAGAMENTO")]
    public class Pagamento
    {
        [Key]
        public int PagamentoID { get; set; }

        [Required]
        public DateTime DataPagamento { get; set; }
        
        [Required]
        public decimal Valor { get; set; }
                
        // 

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
