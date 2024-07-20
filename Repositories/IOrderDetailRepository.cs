using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetail();
        Task<OrderDetail> GetOrderDetailByOrderIdProductId(int OrderId, int ProductId);
        Task Add(OrderDetail orderDetail);
        Task Update(OrderDetail orderDetail);
        Task Delete(int OrderId, int ProductId);
        Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(int OrderId);
    }
}
