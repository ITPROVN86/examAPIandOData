using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private IOrderDetailRepository _orderDetailRepository;
        public OrderDetailController()
        {
            _orderDetailRepository = new OrderDetailRepository();
        }
        // GET: api/<OrderDetailController>
        [HttpGet]
        public async Task<IEnumerable<OrderDetail>> Get()
        {
            return await _orderDetailRepository.GetAllOrderDetail();
        }

        // GET api/<OrderDetailController>/Order/5
        [HttpGet("Order/{id}")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> Get(int id)
        {
            var orderDetails = await _orderDetailRepository.GetOrderDetailByOrderId(id);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }

        // GET api/<OrderDetailController>/5/3
        [HttpGet("{OrderId}/{ProductId}")]
        public async Task<ActionResult<OrderDetail>> GetByOrderIdProductId(int OrderId, int ProductId)
        {
            var orderDetail = await _orderDetailRepository.GetOrderDetailByOrderIdProductId(OrderId, ProductId);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        // POST api/<OrderDetailController>
        [HttpPost]
        public async Task<ActionResult> Post(OrderDetail orderDetail)
        {
            await _orderDetailRepository.Add(orderDetail);
            return Content("Insert success!");
        }

        // PUT api/<OrderDetailController>/5/3
        [HttpPut("{OrderId}/{ProductId}")]
        public async Task<ActionResult> Put(int OrderId, int ProductId, OrderDetail orderDetail)
        {
            var temp = await _orderDetailRepository.GetOrderDetailByOrderIdProductId(OrderId, ProductId);
            if (temp == null)
            {
                return NoContent();
            }
           /* orderDetail.OrderId = OrderId;
            orderDetail.ProductId = ProductId;*/
            await _orderDetailRepository.Update(orderDetail);
            return Content("Update success!");
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int OrderId, int ProductId)
        {
            var temp = await _orderDetailRepository.GetOrderDetailByOrderIdProductId(OrderId, ProductId);
            if (temp == null)
            {
                return NoContent();
            }
            await _orderDetailRepository.Delete(OrderId, ProductId);
            return Content("Delete success!");
        }
    }
}
