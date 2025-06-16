using DemoEFCore.Dal.Configurations;
using DemoEFCore.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DemoEFCore.Dal
{
    public class ProductManagerDbContext : DbContext
    {
        public DbSet<Product> Products { get { return Set<Product>(); } }
        public DbSet<Category> Categories { get { return Set<Category>(); } }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductManagerEF;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;")
                           .LogTo(Console.WriteLine, [DbLoggerCategory.Database.Command.Name], LogLevel.Information)
                           .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        //Que dans une application Bureau (console, wpf, windows forms, 'etc')
        //public override int SaveChanges()
        //{
        //    int rows = base.SaveChanges();
        //    ChangeTracker.Clear();
        //    return rows;
        //}
    }
}
