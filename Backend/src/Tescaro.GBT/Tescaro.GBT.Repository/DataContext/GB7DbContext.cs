using Microsoft.EntityFrameworkCore;
using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Repository
{
    public class GBTContext : DbContext
    {
        public GBTContext(DbContextOptions<GBTContext> options)
           : base(options)
        {
        }        

        public DbSet<Chamado> Chamado { get; set; }
        public DbSet<BancoDados> BancoDados { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<DNS> DNS { get; set; }
        //public DbSet<LogCrud> LogCrud { get; set; }
        //public DbSet<ProcedimentosComuns> ProcedimentosComuns { get; set; }
        //public DbSet<Backlog> Backlog { get; set; }
        //public DbSet<ToDo> ToDo { get; set; }
        //public DbSet<Glossario> Glossario { get; set; }
        //public DbSet<Solicitacao> Solicitacao { get; set; }
    }
}
