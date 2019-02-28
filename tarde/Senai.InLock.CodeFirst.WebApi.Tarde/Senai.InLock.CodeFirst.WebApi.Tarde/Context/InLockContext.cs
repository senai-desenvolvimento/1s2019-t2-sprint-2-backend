using Microsoft.EntityFrameworkCore;
using Senai.InLock.CodeFirst.WebApi.Tarde.Domains;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Context
{
    public class InLockContext : DbContext
    {
        public DbSet<EstudioDomain> Estudios { get; set; }
        public DbSet<JogoDomain> Jogos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=InLock_CodeFirst_Tarde;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
