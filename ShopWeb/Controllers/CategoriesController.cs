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
    public class ProductsController : ControllerBase
    {
        private DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        //api/products
        [HttpGet]
        public IAsyncEnumerable<Product> GetProducts()
        {
            return _context.Products.AsAsyncEnumerable();
        }
        //api/products/1
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

        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody] Product product)
        {

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

            return Ok(product);
           
        }

        [HttpPut]
        public void UpdateProduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(long id)
        {
            _context.Products.Remove(new Product { id = id });
            _context.SaveChanges();
        }

        [HttpGet("redirect")]
        public IActionResult redirect()
        {
            //return Redirect("/api/products/1");
            //            return RedirectToAction(nameof(GetProduct), new { id = 1 });
            return RedirectToRoute(new
            {
                Controller = "Products",
                action = "GetProduct",
                                id = 1
            });
        }
    }
}
