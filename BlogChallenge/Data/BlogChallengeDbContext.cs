using BlogChallenge.Data.Configurations;
using BlogChallenge.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogChallenge.Data
{
    public class BlogChallengeDbContext : DbContext
    {
        public BlogChallengeDbContext(DbContextOptions<BlogChallengeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PostTEntityConfiguration().Configure(modelBuilder.Entity<Post>());
            new CategoryTEntityConfiguration().Configure(modelBuilder.Entity<Category>());
        }
    }
}
