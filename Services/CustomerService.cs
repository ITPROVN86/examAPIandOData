using BusinessObjects;
using ShopDTO;
using System.Net.Http.Json;

namespace Services
{
    public class CustomerService : ICustomerService
    {

        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CustomerDTO>>("api/Customer");
        }

        public async Task<CustomerDTO> GetCustomerById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _httpClient.GetFromJsonAsync<CustomerDTO>($"api/Customer/{id}");
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task Create(CustomerDTO customer)
        {
            await _httpClient.PostAsJsonAsync("api/Customer", customer);
        }

        public async Task Update(CustomerDTO customer)
        {
            await _httpClient.PutAsJsonAsync($"api/Customer/{customer.CustomerId}", customer);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Customer/{id}");
        }
    }
}
