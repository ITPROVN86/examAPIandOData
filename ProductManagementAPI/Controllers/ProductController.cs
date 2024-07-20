using AutoMapper;
using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using ShopDTO;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper)
        {
            _productRepository = new ProductRepository();
            _mapper = mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var products = await _productRepository.GetAllProduct();
            var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return Ok(productDTO);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> PostProduct(Product product)
        {
            await _productRepository.Add(product);
            return Content("Insert success!");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, Product product)
        {
            var temp = await _productRepository.GetProductById(id);
            if (temp == null)
            {
                return NoContent();
            }
            product.ProductId = id;
            await _productRepository.Update(product);
            return Content("Update success!");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var temp = await _productRepository.GetProductById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _productRepository.Delete(id);
            return Content("Delete success!");
        }
    }
}
