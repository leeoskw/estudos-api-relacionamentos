namespace estudos_api_relacionamentos.Entities
{
    public class LivroEntity
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime DataPublicacao { get; set; }
        
       
        public int CategoriaId { get; set; } // chave estrangeira para Categoria
        public CategoriaEntity Categoria{ get; set; } // navegação para Categoria
    }
}
