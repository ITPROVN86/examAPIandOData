using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository;
        public OrderController()
        {
            _orderRepository = new OrderRepository();
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrder()
        {
            return await _orderRepository.GetAllOrder();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult> Post(Order order)
        {
            await _orderRepository.Add(order);
            return Content("Insert success!");
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Order order)
        {
            var temp = await _orderRepository.GetOrderById(id);
            if (temp == null)
            {
                return NoContent();
            }
            order.OrderId = id;
            await _orderRepository.Update(order);
            return Content("Update success!");
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var temp = await _orderRepository.GetOrderById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _orderRepository.Delete(id);
            return Content("Delete success!");
        }
    }
}
