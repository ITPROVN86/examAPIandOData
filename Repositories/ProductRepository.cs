﻿using BusinessObjects;
using DataAccess;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task Add(Product product)
        {
            await ProductDAO.Instance.Add(product);
        }

        public async Task Delete(int id)
        {
            await ProductDAO.Instance.Delete(id);
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await ProductDAO.Instance.GetProductAll();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await ProductDAO.Instance.GetProductById(id);
        }

        public async Task Update(Product product)
        {
            await ProductDAO.Instance.Update(product);
        }

    }
}