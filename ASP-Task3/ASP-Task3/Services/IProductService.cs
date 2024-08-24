using ASP_Task3.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP_Task3.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllByKey(string key);
        Task AddAsync(Product product);
    }
}
