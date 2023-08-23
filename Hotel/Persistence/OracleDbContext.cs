using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Persistence
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Hospede> Hospedes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<TipoQuarto> TipoQuartos { get; set; }

    public OracleDbContext (DbContextOptions<OracleDbContext> options) : base(options)
        {

        }

    }
}
