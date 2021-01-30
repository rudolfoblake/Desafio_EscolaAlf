namespace EscolaAlf_webAPI.Models
{
    public class RespostaAluno
    {
        public RespostaAluno() { }
        public RespostaAluno(int id, int alunoId, int questaoId, int alternativaId)
        {
            this.AlternativaId = id;
            this.AlunoId = alunoId;
            this.QuestaoId = questaoId;
            this.AlternativaId = alternativaId;
        }

        public int Id { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int QuestaoId { get; set; }
        public Questao Questao { get; set; }
        public int AlternativaId { get; set; }
        public Alternativa Alternativa { get; set; }
    }
}