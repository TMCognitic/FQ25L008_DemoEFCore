using DemoEFCore.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore.Dal.Configurations
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", t => {
                    t.HasCheckConstraint("CK_Category_Name", "LEN(TRIM(Name)) > 0");
                });
            
            builder.Property(c => c.Name)
                .HasColumnType("NVARCHAR(50)");

            builder.HasIndex(c => c.Name)
                .IsUnique(true);

            builder.HasData(new Category() { Id = 1, Name = "Frais" }, new Category() { Id = 2, Name = "Glaces" });
        }
    }
}
