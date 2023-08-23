
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    [Table("TB_QUARTOS")]
    public class Quarto
    {
        [Key]
        public int QuartoID { get; set; }

        [Required]
        public string NumeroQuarto { get; set; }

        [Required]        
        public decimal PrecoPorNoite { get; set; }


        public virtual ICollection<TipoQuarto> TipoQuartos{ get; set; }

    }
}
