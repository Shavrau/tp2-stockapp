using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Infra.Data.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //primarykey
            builder.HasKey(t => t.Id);
            //maxleng nome
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            //maxleng description
            builder.Property(p => p.Description).HasMaxLength(250).IsRequired();
            //decimal price
            builder.Property(p => p.Price).HasPrecision(10, 2);
            //chave estrangeira de categoria build hasone +> WithMany HasForeingKey (Atributo)
            builder.HasOne(e => e.Category).WithMany(e => e.Products).HasForeingKey(e => e.CategoryId);
        }
    }
}

