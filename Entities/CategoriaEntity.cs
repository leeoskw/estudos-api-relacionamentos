namespace estudos_api_relacionamentos.Entities
{
    public class CategoriaEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        
        // Relacionamento 1:N com Livros
        public List<LivroEntity> Livros { get; set; }
    }
}
