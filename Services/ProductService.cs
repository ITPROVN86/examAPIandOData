using BusinessObjects;
using ShopDTO;
using System.Net.Http.Json;

namespace Services
{
    public class ProductService : IProductService
    {

        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDTO>> GetProduct()
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProductDTO>>("api/Product");
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductDTO>($"api/Product/{id}");
        }

        public async Task Create(ProductDTO product)
        {
            await _httpClient.PostAsJsonAsync("api/Product", product);
        }

        public async Task Update(ProductDTO product)
        {
            await _httpClient.PutAsJsonAsync($"api/Product/{product.ProductId}", product);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Product/{id}");
        }
    }
}
