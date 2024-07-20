using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO : SingletonBase<OrderDAO>
    {
        public async Task<IEnumerable<Order>> GetOrderAll()
        {
            return await _context.Orders.ToListAsync();
        }
        public async Task<Order> GetOrderById(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(c => c.OrderId == id);
#pragma warning disable CS8603 // Possible null reference return.
            if (order == null) return null;
#pragma warning restore CS8603 // Possible null reference return.
            return order;
        }
        public async Task Add(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Order order)
        {
            var existingItem = await GetOrderById(order.OrderId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(order);
            }

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var order = await GetOrderById(id);
            if (order != null)
            {
                _context.Orders.RemoveRange(order);
                await _context.SaveChangesAsync();
            }
        }

    }
}
