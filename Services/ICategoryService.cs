using BusinessObjects;
using ShopDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategoryById(int id);
        Task Create(CategoryDTO category);
        Task Update(CategoryDTO category);
        Task Delete(int id);
    }
}
