namespace estudos_api_relacionamentos.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<LivroModel> Livros { get; set; }
    }
}
