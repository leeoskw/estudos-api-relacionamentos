namespace estudos_api_relacionamentos.Entities
{
    public class ProfessorEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }


        // navegação
        public ICollection<CursoEntity> Cursos { get; set; } // 1:N
    }
}
