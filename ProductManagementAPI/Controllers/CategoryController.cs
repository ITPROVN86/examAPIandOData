using BusinessObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _categoryRepository;
        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.GetAllCategory();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return await _categoryRepository.GetCategoryById(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> PostCategory(Category category)
        {
            await _categoryRepository.Add(category);
            return Content("Insert success!");
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategory(int id, Category category)
        {
            var temp = await _categoryRepository.GetCategoryById(id);
            if (temp == null)
            {
                return NoContent();
            }
            category.CategoryId = id;
            await _categoryRepository.Update(category);
            return Content("Update success!");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var temp = await _categoryRepository.GetCategoryById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _categoryRepository.Delete(id);
            return Content("Delete success!");
        }
    }
}
