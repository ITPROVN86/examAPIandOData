using BusinessObjects;
using ShopDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProduct();
        Task<ProductDTO> GetProductById(int id);
        Task Create(ProductDTO product);
        Task Update(ProductDTO product);
        Task Delete(int id);
    }
}
