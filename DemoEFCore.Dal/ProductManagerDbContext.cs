using DemoEFCore.Dal.Configurations;
using DemoEFCore.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCore.Dal
{
    public class ProductManagerDbContext : DbContext
    {
        public DbSet<Product> Products { get { return Set<Product>(); } }
        public DbSet<Category> Categories { get { return Set<Category>(); } }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductManagerEF;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
