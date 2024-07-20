using BusinessObjects;
using ShopDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetCustomers();
        Task<CustomerDTO> GetCustomerById(int id);
        Task Create(CustomerDTO category);
        Task Update(CustomerDTO category);
        Task Delete(int id);
    }
}
