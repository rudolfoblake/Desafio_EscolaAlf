using System.Collections.Generic;

namespace EscolaAlf_webAPI.Models
{
    public class Aluno
    {
        public Aluno() { }
        public Aluno(int id, string nome, string sobrenome, string email, string sexo, double media, string situacao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Email = email;
            this.Sexo = sexo;
            this.Media = media;
            this.Situacao = situacao;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public double? Media { get; set; }
        public string Situacao { get; set; }

        public IEnumerable<AlunoProva> AlunoProva { get; set; }
        public IEnumerable<RespostaAluno> RespostaAluno { get; set; }
    }
}