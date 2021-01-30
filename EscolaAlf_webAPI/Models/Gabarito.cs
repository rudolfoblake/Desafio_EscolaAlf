namespace EscolaAlf_webAPI.Models
{
    public class Gabarito
    {
        public Gabarito() { }

        public Gabarito(int id, int questaoId, int alternativaId)
        {
            this.Id = id;
            this.QuestaoId = questaoId;
            this.AlternativaId = alternativaId;
        }

        public int Id { get; set; }
        public int QuestaoId { get; set; }
        public Questao Questao { get; set; }
        public int AlternativaId { get; set; }
        public Alternativa Alternativa { get; set; }        
    }
}