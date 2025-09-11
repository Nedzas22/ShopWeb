using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopWeb.Infrastucture;
using ShopWeb.Models;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ShopWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }

   
        //api/categories/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(long id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

 
    }
}
