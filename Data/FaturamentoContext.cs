using Microsoft.EntityFrameworkCore;
using DistribuidoraAPI.Models;

namespace DistribuidoraAPI.Data
{
    public class FaturamentoContext : DbContext
    {
        public FaturamentoContext(DbContextOptions<FaturamentoContext> options)
            : base(options)
        {
        }

        public DbSet<Faturamento> Faturamentos { get; set; }
    }
}
