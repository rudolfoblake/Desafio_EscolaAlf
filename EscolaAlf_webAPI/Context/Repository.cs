using System.Linq;
using System.Threading.Tasks;
using EscolaAlf_webAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaAlf_webAPI.Context
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        // Alunos
        public async Task<Aluno[]> GetAllAlunosAsync()
        {
            IQueryable<Aluno> query = _context.Alunos;

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno[]> GetAlunoBySituacao(string situacao)
        {
            IQueryable<Aluno> query = _context.Alunos;

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(a => a.Situacao == "Aprovado");

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoById(int alunoId)
        {
            IQueryable<Aluno> query = _context.Alunos;

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(a => a.Id == alunoId);

            return await query.FirstOrDefaultAsync();
        }

        // AlunoProva
        public async Task<AlunoProva[]> GetAllAlunoProvas()
        {
            IQueryable<AlunoProva> query = _context.AlunosProvas;

            query = query.AsNoTracking().OrderBy(ap => ap.Id);

            return await query.ToArrayAsync();
        }

        public async Task<AlunoProva> GetAlunoProvaById(int alunoProvaId)
        {
            IQueryable<AlunoProva> query = _context.AlunosProvas;

            query = query.AsNoTracking()
                         .OrderBy(ap => ap.Id)
                         .Where(ap => ap.Id == alunoProvaId);

            return await query.FirstOrDefaultAsync();
        }

        // Alternativa
        public async Task<Alternativa> GetAlternativaById(int alternativaId)
        {
            IQueryable<Alternativa> query = _context.Alternativas;

            query = query.AsNoTracking()
                         .OrderBy(al => al.Id)
                         .Where(al => al.Id == alternativaId);

            return await query.FirstOrDefaultAsync();
        }

        // Gabarito
        public async Task<Gabarito> GetGabaritoById(int gabaritoId)
        {
            IQueryable<Gabarito> query = _context.Gabaritos;

            query = query.AsNoTracking()
                         .OrderBy(g => g.Id)
                         .Where(g => g.Id == gabaritoId);

            return await query.FirstOrDefaultAsync();
        }

        // Prova
        public async Task<Prova> GetProvaById(int provaId)
        {
            IQueryable<Prova> query = _context.Provas;

            query = query.AsNoTracking()
                         .OrderBy(p => p.Id)
                         .Where(p => p.Id == provaId);

            return await query.FirstOrDefaultAsync();
        }

        // Questao
        public async Task<Questao> GetQuestaoById(int questaoId)
        {
            IQueryable<Questao> query = _context.Questoes;

            query = query.AsNoTracking()
                         .OrderBy(q => q.Id)
                         .Where(q => q.Id == questaoId);

            return await query.FirstOrDefaultAsync();
        }

        // RespostaAluno
        public async Task<RespostaAluno> GetRespostaAlunoById(int respostaAlunoId)
        {
            IQueryable<RespostaAluno> query = _context.RespostasAlunos;

            query = query.AsNoTracking()
                         .OrderBy(ra => ra.Id)
                         .Where(ra => ra.Id == respostaAlunoId);

            return await query.FirstOrDefaultAsync();
        }

    }
}