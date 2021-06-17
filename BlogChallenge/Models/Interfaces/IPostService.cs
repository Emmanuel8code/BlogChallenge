using BlogChallenge.Models.DTOs;
using BlogChallenge.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogChallenge.Models.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostsListDto>> GetAllPosts();
        Task<Post> GetPostById(int id);
        Task AddPost(Post post);
        Task UpdatePost(Post post);
        Task<Post> DeletePost(int id);
        bool ExistPost(int id);
    }
}
