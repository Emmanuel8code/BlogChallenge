using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogChallenge.Models.DTOs
{
    public class PostsListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
    }
}
