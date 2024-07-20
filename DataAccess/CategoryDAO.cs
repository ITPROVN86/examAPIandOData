using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO:SingletonBase<CategoryDAO>
    {
        public async Task<IEnumerable<Category>> GetCategoryAll()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
#pragma warning disable CS8603 // Possible null reference return.
            if (category == null) return null;
#pragma warning restore CS8603 // Possible null reference return.
            return category;
        }
        public async Task Add(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Category category)
        {
            var existingItem = await GetCategoryById(category.CategoryId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(category);
            }

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var category = await GetCategoryById(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

    }
}
