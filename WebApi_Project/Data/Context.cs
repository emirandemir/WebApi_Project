using Microsoft.EntityFrameworkCore;

namespace WebApi_Project.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) 
        { 
        
        
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
