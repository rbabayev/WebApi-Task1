using Microsoft.AspNetCore.Mvc;
using WebApi_Task1.Data;
using WebApi_Task1.DTOs;
using WebApi_Task1.Entities;

namespace WebApi_Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly EcommerceDbContext dbContext;
        public CustomerController(EcommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(dbContext.Customers.ToList());
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerDto customerDto)
        {
            var customerEntity = new Customer()
            {
                Name = customerDto.Name,
                Surname = customerDto.Surname,
            };


            dbContext.Customers.Add(customerEntity);
            dbContext.SaveChanges();

            return Ok(customerEntity);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            var customer = dbContext.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            customer.Name = customerDto.Name;
            customer.Surname = customerDto.Surname;

            dbContext.SaveChanges();
            return Ok(customer);
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = dbContext.Customers.Find(id);
            if (customer == null) { return NotFound(); }
            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();
            return Ok("Customer Deleted");
        }
    }
}
