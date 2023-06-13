using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tescaro.GBT.Domain.Identity;
using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Repository
{
    public class GBTContext : IdentityDbContext<User, Role, long, IdentityUserClaim<long>, 
                                                UserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public GBTContext(DbContextOptions<GBTContext> options)
           : base(options)
        {
        }        

        public DbSet<Chamado> Chamado { get; set; }
        public DbSet<BancoDados> BancoDados { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<DNS> DNS { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        //public DbSet<LogCrud> LogCrud { get; set; }
        //public DbSet<ProcedimentosComuns> ProcedimentosComuns { get; set; }
        //public DbSet<Backlog> Backlog { get; set; }
        //public DbSet<ToDo> ToDo { get; set; }
        //public DbSet<Glossario> Glossario { get; set; }
        //public DbSet<Solicitacao> Solicitacao { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(x => new {x.UserId, x.RoleId});

                userRole.HasOne(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId).IsRequired();
                userRole.HasOne(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId).IsRequired();

            });
        }

    }
}
