using estudos_api_relacionamentos.Entities;
using Microsoft.EntityFrameworkCore;

namespace estudos_api_relacionamentos.DataContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<LivroEntity> Livros{ get; set; }
        public DbSet<CategoriaEntity> Categorias { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Relação N:1 entre Livro e Categoria

            modelBuilder.Entity<LivroEntity>()
                .HasOne(l => l.Categoria)
                .WithMany(c => c.Livros)
                .HasForeignKey(l => l.CategoriaId);
        }
    }
}
