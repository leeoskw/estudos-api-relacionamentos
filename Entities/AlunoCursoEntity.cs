namespace estudos_api_relacionamentos.Entities
{
    public class AlunoCursoEntity
    {
        // tudo navegação. Referências para os dois lados N da relação
        public int EstudanteId { get; set; }
        public AlunoEntity Estudante { get; set; }
        public int CursoId { get; set; }
        public CursoEntity Curso { get; set; }
    }
}
