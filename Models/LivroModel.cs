namespace estudos_api_relacionamentos.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int CategoriaId { get; set; } // Excluindo a referência de volta à Categoria
    }
}
