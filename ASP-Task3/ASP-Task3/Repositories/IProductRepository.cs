using ASP_Task3.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP_Task3.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(string key = "");
        Task AddAsync(Product product);
    }
}
