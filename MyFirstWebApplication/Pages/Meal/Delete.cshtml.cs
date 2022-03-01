using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFirstWebApplication.Data;
using MyFirstWebApplication.Models;

namespace MyFirstWebApplication.Pages.Meal
{
    [Authorize(Roles = "admin")]
    public class DeleteModel : PageModel
    {
        private readonly MyFirstWebApplication.Data.ApplicationContext _context;

        public DeleteModel(MyFirstWebApplication.Data.ApplicationContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ArticleModel = await _context.ArticleModels.FindAsync(id);

            if (ArticleModel != null)
            {
                _context.ArticleModels.Remove(ArticleModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
