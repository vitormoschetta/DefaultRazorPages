

using System.Collections.Generic;
using System.Threading.Tasks;
using DefaultRazorPages.Data;
using DefaultRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace DefaultRazorPages.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet() => Page();

        [BindProperty]
        public Product Product { get; set; }        
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();            
            
            var emptyProduct = new Product();

            if (await TryUpdateModelAsync<Product>(emptyProduct,"Product", s => s.Name, s => s.Price))
            {                
                _context.Product.Add(emptyProduct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;
        }
        
    }
}