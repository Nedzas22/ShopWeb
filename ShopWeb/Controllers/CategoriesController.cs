using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopWeb.Infrastucture;
using ShopWeb.Models;

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
        //api/products
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }
        //api/products/1


        //api/categories/1
 


    }
}
