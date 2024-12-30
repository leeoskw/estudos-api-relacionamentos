namespace estudos_api_relacionamentos.Entities
{
    public class AlunoCursoEntity
    {
        // tudo navegação. Referências para os dois lados N da relação
        public int AlunoId { get; set; }
        public AlunoEntity Aluno { get; set; }
        public int CursoId { get; set; }
        public CursoEntity Curso { get; set; }
    }
}
