using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopWeb.Infrastucture;

namespace ShopWeb.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(long id = 1)
        {
            return View(await _context.Products.FindAsync(id));
        }

        public IActionResult Common(long id)
        {
            return View("/Views/Shared/Common.cshtml");
        }
        public async Task<IActionResult> List()
        {
            ViewBag.AveragePrice = await _context.Products.AverageAsync(p => p.price);

            return View(await _context.Products.ToListAsync());
        }

        public IActionResult Redirect()
        {
            TempData["value"] = "TempData value";

            return RedirectToAction("Index", new {id = 1});
        }

        public IActionResult Html()
        {
          return View((object)"This is a <h3><i> string</i></h3>");
        }
    }
}
