using Tescaro.GBT.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Tescaro.GBT.WebAPI.DataContext
{
    public class GBTDbContext : DbContext
    {
        public GBTDbContext(DbContextOptions<GBTDbContext> options)
           : base(options)
        {
        }        

        public DbSet<Chamado> Chamado { get; set; }
        //public DbSet<BaseDB> BaseDB { get; set; }
        //public DbSet<Cliente> Cliente { get; set; }
        //public DbSet<LogCrud> LogCrud { get; set; }
        //public DbSet<ProcedimentosComuns> ProcedimentosComuns { get; set; }
        //public DbSet<Backlog> Backlog { get; set; }
        //public DbSet<DNS> DNS { get; set; }
        //public DbSet<ToDo> ToDo { get; set; }
        //public DbSet<Glossario> Glossario { get; set; }
        //public DbSet<Solicitacao> Solicitacao { get; set; }
    }
}
