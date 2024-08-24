using ASP_Task3.Entities;
using ASP_Task3.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP_Task3.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Product product)
        {
            await _repository.AddAsync(product);
        }

        public async Task<List<Product>> GetAllByKey(string key)
        {
            return await _repository.GetAllAsync(key);
        }
    }
}




