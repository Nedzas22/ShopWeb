using Microsoft.AspNetCore.Mvc;
using ShopWeb.Infrastucture;
using ShopWeb.Models;
using System.Linq;

namespace ShopWeb.Controllers
{
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
       public IEnumerable<Product> GetProducts()
        {
           return _context.Products;
        }
        //api/products/1
        [HttpGet("{id}")]
        public Product GetProduct(long id,[FromServices]ILogger<ProductsController> logger)
        {
            logger.LogDebug("GetProduct Action Invoked");
            return _context.Products.Find(id);
        }
    }
}
