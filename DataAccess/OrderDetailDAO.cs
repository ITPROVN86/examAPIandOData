using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO : SingletonBase<OrderDetailDAO>
    {
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailAll()
        {
            return await _context.OrderDetails.ToListAsync();
        }
        public async Task<OrderDetail> GetOrderDetailByOrderIdProductId(int orderId, int productId)
        {
            var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(c => c.OrderId == orderId && c.ProductId==productId);
#pragma warning disable CS8603 // Possible null reference return.
            if (orderDetail == null) return null;
#pragma warning restore CS8603 // Possible null reference return.
            return orderDetail;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(int orderId)
        {
            var orderDetails = await _context.OrderDetails.Where(c => c.OrderId == orderId).ToListAsync();
#pragma warning disable CS8603 // Possible null reference return.
            if (orderDetails == null) return null;
#pragma warning restore CS8603 // Possible null reference return.
            return orderDetails;
        }
        public async Task Add(OrderDetail orderDetail)
        {
            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
        }
        public async Task Update(OrderDetail orderDetail)
        {
            var existingItem = await GetOrderDetailByOrderIdProductId(orderDetail.OrderId, orderDetail.ProductId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(orderDetail);
            }

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int orderId, int productId)
        {
            var orderDetail = await GetOrderDetailByOrderIdProductId(orderId, productId);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                await _context.SaveChangesAsync();
            }
        }

    }
}
