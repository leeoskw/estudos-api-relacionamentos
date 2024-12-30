namespace estudos_api_relacionamentos.Entities
{
    public class EnderecoEntity
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        
        // navegação
        public int AlunoId { get; set; }
        public AlunoEntity Aluno { get; set; }
    }
}
