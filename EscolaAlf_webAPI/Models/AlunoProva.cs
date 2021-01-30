using System.Collections.Generic;

namespace EscolaAlf_webAPI.Models
{
    public class AlunoProva
    {
        public AlunoProva() { }
        public AlunoProva(int id, int alunoId, int provaId, double nota)
        {
            Id = id;
            AlunoId = alunoId;
            ProvaId = provaId;
            Nota = nota;
        }

        public int Id { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int ProvaId { get; set; }
        public Prova Prova { get; set; }
        public double? Nota { get; set; }
    }
}