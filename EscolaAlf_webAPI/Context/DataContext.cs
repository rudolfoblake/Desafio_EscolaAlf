using EscolaAlf_webAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EscolaAlf_webAPI.Context
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       public DbSet<Aluno> Alunos { get; set; }
       public DbSet<Prova> Provas { get; set; }
       public DbSet<AlunoProva> AlunosProvas { get; set; }
       public DbSet<RespostaAluno> RespostasAlunos { get; set; }
       public DbSet<Gabarito> Gabaritos { get; set; }
       public DbSet<Questao> Questoes { get; set; }
       public DbSet<Alternativa> Alternativas { get; set; }

       protected override void OnModelCreating(ModelBuilder builder)
       {
           foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
           {
               relationship.DeleteBehavior = DeleteBehavior.Restrict;
           }
       }
    }
}
