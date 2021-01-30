using System;
using System.Collections.Generic;

namespace EscolaAlf_webAPI.Models
{
    public class Prova
    {
        public Prova() { }
        public Prova(int id, string nome, string descricao, DateTime dtProva)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.DtProva = dtProva;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DtProva { get; set; }
        public IEnumerable<AlunoProva> AlunoProva { get; set; }
        public IEnumerable<Questao> Questao { get; set; }
    }
}