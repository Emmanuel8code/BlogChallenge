using BlogChallenge.Data;
using BlogChallenge.Models.DTOs;
using BlogChallenge.Models.Entities;
using BlogChallenge.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogChallenge.Models.Services
{
    public class PostService : IPostService
    {
        private readonly BlogChallengeDbContext _context;
        public PostService(BlogChallengeDbContext context)
        {
            _context = context;
        }
        
        public async Task AddPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post != null)
            {
                _context.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PostDto>> GetAllPosts()
        {
            return await _context.Posts.Select(x => new PostDto { Id = x.Id, Title = x.Title }).ToListAsync();
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _context.Posts.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdatePost(Post post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();
        }

        public bool ExistPost(int id)
        {
            return _context.Posts.Any(x => x.Id == id);
        }
    }
}
