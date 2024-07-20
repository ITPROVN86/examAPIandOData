using BusinessObjects;
using DataAccess;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public async Task Add(OrderDetail orderDetail)
        {
            await OrderDetailDAO.Instance.Add(orderDetail);
        }

        public async Task Delete(int OrderId, int ProductId)
        {
            await OrderDetailDAO.Instance.Delete(OrderId, ProductId);
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetail()
        {
            return await OrderDetailDAO.Instance.GetOrderDetailAll();
        }

        public async Task<OrderDetail> GetOrderDetailByOrderIdProductId(int OrderId, int ProductId)
        {
            return await OrderDetailDAO.Instance.GetOrderDetailByOrderIdProductId(OrderId,ProductId);
        }

        public async Task Update(OrderDetail orderDetail)
        {
            await OrderDetailDAO.Instance.Update(orderDetail);
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(int OrderId)
        {
            return await OrderDetailDAO.Instance.GetOrderDetailByOrderId(OrderId);
        }

    }
}
