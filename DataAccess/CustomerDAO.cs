using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerDAO : SingletonBase<CustomerDAO>
    {
        public async Task<IEnumerable<Customer>> GetCustomerAll()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
#pragma warning disable CS8603 // Possible null reference return.
            if (customer == null) return null;
#pragma warning restore CS8603 // Possible null reference return.
            return customer;
        }
        public async Task Add(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Customer customer)
        {
            var existingItem = await GetCustomerById(customer.CustomerId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(customer);
            }
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var customer = await GetCustomerById(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

    }
}
