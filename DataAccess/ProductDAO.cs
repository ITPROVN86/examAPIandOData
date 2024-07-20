using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO : SingletonBase<ProductDAO>
    {
        public async Task<IEnumerable<Product>> GetProductAll()
        {
            return await _context.Products.Include(c => c.Category).ToListAsync();
        }
        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.ProductId == id);
#pragma warning disable CS8603 // Possible null reference return.
            if (product == null) return null;
#pragma warning restore CS8603 // Possible null reference return.
            return product;
        }
        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Product product)
        {
            var existingItem = await GetProductById(product.ProductId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(product);
            }

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var product = await GetProductById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

    }
}
