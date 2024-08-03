using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Project.Data;

namespace WebApi_Project.IRepositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(int id);
        public Task<Product> CreateAsync(Product product);
        public Task UpdateAsync(Product product);
        public Task DeleteAsync(int id);
    }
}
