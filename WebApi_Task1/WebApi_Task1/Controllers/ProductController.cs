using Microsoft.AspNetCore.Mvc;
using WebApi_Task1.Data;
using WebApi_Task1.DTOs;
using WebApi_Task1.Entities;

namespace WebApi_Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly EcommerceDbContext dbContext;
        public ProductController(EcommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(dbContext.Products.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProductsById(int id)
        {
            var product = dbContext.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetHigherPrice(ProductDto productDto)
        {
            var product = dbContext.Products
      .Where(p => p.Price > 0)
      .OrderByDescending(p => p.Price)
      .Select(p => new ProductDto
      {
          Name = productDto.Name,
          Price = productDto.Price,
          Discount = productDto.Discount
      }).FirstOrDefault();
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetHigherDiscount(ProductDto productDto)
        {
            var product = dbContext.Products
      .Where(p => p.Price > 0)
      .OrderByDescending(p => p.Discount)
      .Select(p => new ProductDto
      {
          Name = productDto.Name,
          Price = productDto.Price,
          Discount = productDto.Discount
      }).ToList();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductDto addProductDto)
        {
            var productEntity = new Product()
            {
                Name = addProductDto.Name,
                Price = addProductDto.Price,
                Discount = addProductDto.Discount
            };


            dbContext.Products.Add(productEntity);
            dbContext.SaveChanges();

            return Ok(productEntity);
        }

        [HttpPut]
        public IActionResult UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var product = dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updateProductDto.Name;
            product.Price = updateProductDto.Price;
            product.Discount = updateProductDto.Discount;

            dbContext.SaveChanges();
            return Ok(product);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = dbContext.Products.Find(id);
            if (product == null) { return NotFound(); }
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return Ok("Product Deleted");
        }
    }
}
