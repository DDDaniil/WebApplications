using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstWebApplication.Data;
using MyFirstWebApplication.Models;

namespace MyFirstWebApplication.Pages.Users
{
    [Authorize(Roles = "admin")]
    public class CreateModel : PageModel
    {
        private readonly MyFirstWebApplication.Data.ApplicationContext _context;

        public CreateModel(MyFirstWebApplication.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");

            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
