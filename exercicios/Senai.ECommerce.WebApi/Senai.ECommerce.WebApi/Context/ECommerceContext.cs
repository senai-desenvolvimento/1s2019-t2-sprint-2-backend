using Microsoft.EntityFrameworkCore;
using Senai.ECommerce.WebApi.Domains;

namespace Senai.ECommerce.WebApi.Context
{
    public class ECommerceContext : DbContext
    {
        public DbSet<ProdutoDomain> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=ECommerce; integrated security=true");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
