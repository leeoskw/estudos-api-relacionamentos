using System.Net;

namespace estudos_api_relacionamentos.Entities
{
    public class AlunoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        
        // navegação 
        public EnderecoEntity Endereco{ get; set; } // 1:1
        public ICollection<AlunoCursoEntity> AlunoCurso { get; set; } // N:N
    }
}
