using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopWeb.Infrastucture;
using ShopWeb.Models;

namespace ShopWeb.Pages
{
    public class EditModel : PageModel
    {
        private DataContext _context;
        public Product Product { get; set; }
        public EditModel(DataContext context)
        {
            _context = context;
        }

        public async Task OnGet(long id)
        {
            Product = await _context.Products.FindAsync(id);

        }

        public async Task<IActionResult> OnPostAsync(long id, decimal price)
        {
           Product product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.price = price;
            }
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
