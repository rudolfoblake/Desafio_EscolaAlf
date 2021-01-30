using System.Threading.Tasks;
using EscolaAlf_webAPI.Models;

namespace EscolaAlf_webAPI.Context
{
    public interface IRepository
    {
        // Geral

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Alunos
        Task<Aluno[]> GetAllAlunosAsync();
        Task<Aluno[]> GetAlunoBySituacao(string situacao);
        Task<Aluno> GetAlunoById(int precoId);

        // AlunoProva
        Task<AlunoProva[]> GetAllAlunoProvas();
        Task<AlunoProva> GetAlunoProvaById(int alunoProvaId);

        // Alternativa
        Task<Alternativa> GetAlternativaById(int alternativaId);

        // Gabarito
        Task<Gabarito> GetGabaritoById(int gabaritoId);

        // Prova
        Task<Prova> GetProvaById(int provaId);

        // Questao
        Task<Questao> GetQuestaoById(int questaoId);

        // RespostaAluno
        Task<RespostaAluno> GetRespostaAlunoById(int respostaAlunoId);


    }
}