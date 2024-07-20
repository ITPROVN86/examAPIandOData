using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _customerRepository;
        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            return await _customerRepository.GetAllCustomer();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult> Post(Customer customer)
        {
            await _customerRepository.Add(customer);
            return Content("Insert success!");
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Customer customer)
        {
            var temp = await _customerRepository.GetCustomerById(id);
            if (temp == null)
            {
                return NoContent();
            }
            customer.CustomerId = id;
            await _customerRepository.Update(customer);
            return Content("Update success!");
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var temp = await _customerRepository.GetCustomerById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _customerRepository.Delete(id);
            return Content("Delete success!");
        }
    }
}
