using Microsoft.AspNetCore.Mvc;
using WebApi_Task1.Data;
using WebApi_Task1.DTOs;
using WebApi_Task1.Entities;

namespace WebApi_Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly EcommerceDbContext dbContext;
        public OrderController(EcommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Ok(dbContext.Orders.ToList());
        }

        [HttpPost]
        public IActionResult AddOrder(OrderDto orderDto)
        {
            var orderEntity = new Order()
            {
                OrderDate = orderDto.OrderDate,
                ProductId = orderDto.ProductId,
                CustomerId = orderDto.CustomerId
            };


            dbContext.Orders.Add(orderEntity);
            dbContext.SaveChanges();

            return Ok(orderEntity);
        }

        [HttpPut]
        public IActionResult UpdateOrder(int id, OrderDto orderDto)
        {
            var order = dbContext.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            order.OrderDate = orderDto.OrderDate;
            order.ProductId = orderDto.ProductId;
            order.CustomerId = orderDto.CustomerId;

            dbContext.SaveChanges();
            return Ok(order);
        }

        [HttpDelete]
        public IActionResult DeleteOrder(int id)
        {
            var order = dbContext.Orders.Find(id);
            if (order == null) { return NotFound(); }
            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();
            return Ok("Order Deleted");
        }
    }
}
