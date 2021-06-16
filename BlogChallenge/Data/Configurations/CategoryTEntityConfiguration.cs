using BlogChallenge.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogChallenge.Data.Configurations
{
    public class CategoryTEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
