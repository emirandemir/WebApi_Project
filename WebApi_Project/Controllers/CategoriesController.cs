using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Project.Data;

namespace WebApi_Project.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly Context _context;

        public CategoriesController(Context context)
        {
            _context = context;
        }

        [HttpGet("{id}/products")]
        public IActionResult GetCategoryWithProductAsync(int id)
        {
           var data = _context.Categories.Include(x=>x.Products).SingleOrDefault(x=>x.ID == id);

            if (data == null)
            {
                return NotFound(id);
            }

            return Ok(data);

        }
    }
}
