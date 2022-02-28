using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstWebApplication.Data;
using MyFirstWebApplication.Models;

namespace MyFirstWebApplication.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly MyFirstWebApplication.Data.UserContext _context;

        public EditModel(MyFirstWebApplication.Data.UserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ArticleModel ArticleModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ArticleModel = await _context.ArticleModels.FirstOrDefaultAsync(m => m.Id == id);

            if (ArticleModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ArticleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleModelExists(ArticleModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArticleModelExists(int id)
        {
            return _context.ArticleModels.Any(e => e.Id == id);
        }
    }
}
