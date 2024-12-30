using estudos_api_relacionamentos.Data.Repositories;
using estudos_api_relacionamentos.Entities;
using System.Net;

namespace estudos_api_relacionamentos.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        // implementa as repositories aqui

        IRepositoryGenerico<AlunoEntity> Alunos { get; }
        IRepositoryGenerico<EnderecoEntity> Enderecos{ get; }
        IRepositoryGenerico<CursoEntity> Cursos { get; }
        IRepositoryGenerico<ProfessorEntity> Professores { get; }
        Task SaveAsync();
    }
}
