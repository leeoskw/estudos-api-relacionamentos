using estudos_api_relacionamentos.Data.Repositories;
using estudos_api_relacionamentos.DataContext;
using estudos_api_relacionamentos.Entities;

namespace estudos_api_relacionamentos.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IRepositoryGenerico<AlunoEntity> Alunos { get; }

        public IRepositoryGenerico<EnderecoEntity> Enderecos { get; }

        public IRepositoryGenerico<CursoEntity> Cursos { get; }

        public IRepositoryGenerico<ProfessorEntity> Professores { get; }


        public UnitOfWork(ApplicationContext context, IRepositoryGenerico<AlunoEntity> alunoRepository, IRepositoryGenerico<EnderecoEntity> enderecoRepository, IRepositoryGenerico<CursoEntity> cursoRepository, IRepositoryGenerico<ProfessorEntity> professorRepository)
        {
            _context = context;
            Alunos = alunoRepository;
            Enderecos = enderecoRepository;
            Cursos = cursoRepository;
            Professores = professorRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
