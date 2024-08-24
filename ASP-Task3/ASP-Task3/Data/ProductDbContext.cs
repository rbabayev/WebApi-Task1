using ASP_Task3.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP_Task3.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}
