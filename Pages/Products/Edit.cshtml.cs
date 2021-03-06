

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DefaultRazorPages.Data;
using DefaultRazorPages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DefaultRazorPages.Pages.Products
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public async Task OnGet(Guid id)
        {
            Product = await _context.Product.FirstOrDefaultAsync(x => x.Id == id);        
        }

        [BindProperty]
        public Product Product { get; set; }        
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();            
                        
            _context.Product.Update(Product);            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        
    }
}