using Microsoft.EntityFrameworkCore;  // Necessário para DbContext e DbContextOptions
using DistribuidoraAPI.Models;  // Necessário para a classe Faturamento

namespace DistribuidoraAPI.Data
{
    // Definição do FaturamentoContext herdando de DbContext
    public class FaturamentoContext : DbContext
    {
        // Construtor que aceita DbContextOptions e passa para a classe base
        public FaturamentoContext(DbContextOptions<FaturamentoContext> options)
            : base(options)
        {
        }

        // DbSet para a entidade Faturamento
        public DbSet<Faturamento> Faturamentos { get; set; }
    }
}
