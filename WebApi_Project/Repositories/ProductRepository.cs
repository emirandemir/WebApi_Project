using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Project.Data;
using WebApi_Project.IRepositories;

namespace WebApi_Project.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        
        public async Task<Product> CreateAsync(Product product)
        {
           await _context.Products.AddAsync(product);
           await _context.SaveChangesAsync();

           return product;
        }

        public async Task DeleteAsync(int id)
        {
            var removedEntity = await _context.Products.FindAsync(id);

            _context.Products.Remove(removedEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.AsNoTracking().SingleOrDefaultAsync(x=>x.ID==id);
        }

        public async Task UpdateAsync(Product product)
        {
              var unchangedEntity = await _context.Products.FindAsync(product.ID);
              _context.Entry(unchangedEntity).CurrentValues.SetValues(product);

             await _context.SaveChangesAsync();
        }
    }
}
