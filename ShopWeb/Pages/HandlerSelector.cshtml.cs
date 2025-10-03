using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopWeb.Infrastucture;
using ShopWeb.Models;

namespace ShopWeb.Pages
{
    public class HandlerSelectorModel : PageModel
    {
        private DataContext _context;
        public Product Product { get; set; }
        public HandlerSelectorModel(DataContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(long id = 1)
        {
            Product = await _context.Products.FindAsync(id);

        }

        public async Task OnGetCategoryAsync(long id = 1)
        {
            Product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.id == id);

        }
    }
}
