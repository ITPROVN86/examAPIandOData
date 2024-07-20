using AutoMapper;
using BusinessObjects;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repositories;
using ShopDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductOData.Controllers
{
    [Route("odata/Category")]
    [ApiController]
    public class CategoryController : ODataController
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
        }
        [EnableQuery]
        // GET: api/Category
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var list = await categoryRepository.GetAllCategory();
            //var categoryDTO = _mapper.Map<IEnumerable<CategoryDTO>>(list);
            return Ok(list);
        }

        [EnableQuery]
        [HttpGet("{key}")]
 /*       [ODataRoute("Category({key})")]*/
        // GET: api/Category/5
        public async Task<ActionResult> GetById([FromODataUri] int key)
        {
            var category = await categoryRepository.GetCategoryById(key);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{key}")]
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await categoryRepository.GetCategoryById(key);
            if (exist == null)
            {
                return NotFound();
            }
            category.CategoryId = exist.CategoryId;
            //exist.SpecializationName = student.SpecializationName;
            categoryRepository.Update(category);

            return Created(category);
        }

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            categoryRepository.Add(category);

            return Created(category);
        }

        // DELETE: api/Category/5
        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            var category = await categoryRepository.GetCategoryById(key);
            if (category == null)
            {
                return NotFound();
            }

            categoryRepository.Delete(key);

            return Content("Delete success!");
        }

    }
}
