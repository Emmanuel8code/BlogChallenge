using BlogChallenge.Data;
using BlogChallenge.Models.Entities;
using BlogChallenge.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogChallenge.Models.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogChallengeDbContext _context;
        public CategoryService(BlogChallengeDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category != null)
            {
                _context.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SelectListItem>> GetSelectListCategories()
        {
            List<Category> listOfCategories = (List<Category>)await GetAllCategories();

            List<SelectListItem> itemsOfCategories = listOfCategories.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Title.ToString(),
                    Value = d.Id.ToString()
                };
            });

            return itemsOfCategories;
        }
    }
}
