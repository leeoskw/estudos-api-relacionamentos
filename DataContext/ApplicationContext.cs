using estudos_api_relacionamentos.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace estudos_api_relacionamentos.DataContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<LivroEntity> Livros{ get; set; }
        public DbSet<CategoriaEntity> Categorias { get; set; }


        public DbSet<AlunoEntity> Estudantes { get; set; }
        public DbSet<EnderecoEntity> Enderecos { get; set; }
        public DbSet<CursoEntity> Cursos { get; set; }
        public DbSet<ProfessorEntity> Professores { get; set; }
        public DbSet<AlunoCursoEntity> EstudantesCursos { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // chaves primárias
            modelBuilder.Entity<AlunoCursoEntity>()
                .HasKey(ec => new { ec.EstudanteId, ec.CursoId});

            // Relação N:1 entre Livro e Categoria

            modelBuilder.Entity<LivroEntity>()
                .HasOne(l => l.Categoria)
                .WithMany(c => c.Livros)
                .HasForeignKey(l => l.CategoriaId);


            // Tabela intermediária a partir de uma relação N:N entre Estudante e Curso.
            // Fazendo o lado 'Um estudante tem vários EstudanteCurso'
            
            modelBuilder.Entity<AlunoCursoEntity>()
                .HasOne(e => e.Estudante)
                .WithMany(ec => ec.AlunoCurso)
                .HasForeignKey(e => e.EstudanteId);

            // Fazendo o outro lado 'Um curso tem vários EstudanteCurso'
            modelBuilder.Entity<AlunoCursoEntity>()
                .HasOne(c => c.Curso)
                .WithMany(ec => ec.EstudanteCurso)
                .HasForeignKey(c => c.CursoId);

            

            // Relação N:1
            modelBuilder.Entity<AlunoEntity>()
                .HasOne(a => a.Endereco)
                .WithOne(a => a.Aluno)
                .HasForeignKey<EnderecoEntity>(a => a.AlunoId);

            
            // Relação N:N
            modelBuilder.Entity<CursoEntity>()
                .HasOne(c => c.Professor)
                .WithMany(p => p.Cursos)
                .HasForeignKey(c => c.ProfessorId);
        }
    }
}
