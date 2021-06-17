using BlogChallenge.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogChallenge.Data.Configurations
{
    public class PostTEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.Content)
                .HasMaxLength(40000)
                .IsRequired();

            builder.Property(b => b.Image);

            builder.Property(b => b.CreatedDate)
                .IsRequired();

            builder.HasOne(b => b.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(b => b.CategoryId);
        }
    }
}
