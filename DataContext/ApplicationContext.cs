using Microsoft.EntityFrameworkCore;

namespace estudos_api_relacionamentos.DataContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Tabela> nomeTabela { get; set; }
    }
}
