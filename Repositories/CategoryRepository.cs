using BusinessObjects;
using DataAccess;

namespace Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        public async Task Add(Category category)
        {
            await CategoryDAO.Instance.Add(category);
        }

        public async Task Delete(int id)
        {
            await CategoryDAO.Instance.Delete(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await CategoryDAO.Instance.GetCategoryAll();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await CategoryDAO.Instance.GetCategoryById(id);
        }

        public async Task Update(Category category)
        {
            await CategoryDAO.Instance.Update(category);
        }

    }
}
