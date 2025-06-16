using DemoEFCore.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEFCore.Dal.Configurations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", p => {
                p.HasCheckConstraint("CK_Product_Name", "LEN(TRIM(Name)) > 0");
                p.HasCheckConstraint("CK_Product_Price", "Price > 0");
            });

            builder.Property(p => p.Name)
                .HasColumnType("NVARCHAR(128)");

            builder.Property(p => p.Description)
                .HasColumnType("NVARCHAR(500)");


            builder.HasData(
                new Product() { ProductId = 1, Name = "Salade", Description = "Salade du jardin", Price = 3.99, CategoryId = 1 },
                new Product() { ProductId = 2, Name = "Glace", Description = "Häagen-Dazs", Price = 7.99, CategoryId = 2 }
                );
        }
    }
}
