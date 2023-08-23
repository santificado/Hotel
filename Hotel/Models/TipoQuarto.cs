using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    [Table("TB_TP_QUARTOS")]
    public class TipoQuarto
    {
        [Key]
        public int TipoQuartoID { get; set; }

        [Required]
        public string Descricao { get; set; }

        public virtual ICollection<Quarto> Quartos { get; set; }
  }  
}