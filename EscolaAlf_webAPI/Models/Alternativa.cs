using System.Collections.Generic;

namespace EscolaAlf_webAPI.Models
{
    public class Alternativa
    {

        public Alternativa() { }
        public Alternativa(int id, int numeroAlternativa, int questaoId, string descricao, string respostaCorreta)
        {
            Id = id;
            NumeroAlternativa = numeroAlternativa;
            QuestaoId = questaoId;
            Descricao = descricao;
            RespostaCorreta = respostaCorreta;
        }

        public int Id { get; set; }
        public int NumeroAlternativa { get; set; }
        public int QuestaoId { get; set; }
        public Questao Questao { get; set; }
        public string Descricao { get; set; }
        public string RespostaCorreta { get; set; }
        public IEnumerable<RespostaAluno> RespostaAluno { get; set; }
        public IEnumerable<Gabarito> Gabarito { get; set; }
    }
}