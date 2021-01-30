using System.Collections.Generic;

namespace EscolaAlf_webAPI.Models
{
    public class Questao
    {
        public Questao() { }
        public Questao(int id, int provaId, int numeroQuestao, string enunciado, int peso)
        {
            this.Id = id;
            this.ProvaId = provaId;
            this.NumeroQuestao = numeroQuestao;
            this.Enunciado = enunciado;
            this.Peso = peso;
        }

        public int Id { get; set; }
        public int ProvaId { get; set; }
        public Prova Prova { get; set; }
        public int NumeroQuestao { get; set; }
        public string Enunciado { get; set; }
        public int Peso { get; set; }
        public IEnumerable<Alternativa> Alternativa { get; set; }
        public IEnumerable<Gabarito> Gabarito { get; set; }
        public IEnumerable<RespostaAluno> RespostaAluno { get; set; }
    }
}