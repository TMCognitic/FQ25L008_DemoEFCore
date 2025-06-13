using DemoEFCore.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore.Dal.Configurations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.Property(p => p.Name)
                .HasColumnType("NVARCHAR(128)");

            builder.Property(p => p.Description)
                .HasColumnType("NVARCHAR(500)");
        }
    }
}
