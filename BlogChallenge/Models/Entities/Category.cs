using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogChallenge.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
