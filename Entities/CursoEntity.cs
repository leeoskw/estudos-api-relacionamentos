namespace estudos_api_relacionamentos.Entities
{
    public class CursoEntity
    {
        public int Id { get; set; }
        public string Materia { get; set; }
        
        
    // navegação
        public int ProfessorId { get; set; } // N:1
        public ProfessorEntity Professor { get; set; }
        public ICollection<AlunoCursoEntity> EstudanteCurso { get; set; } // N:N
    }
}
