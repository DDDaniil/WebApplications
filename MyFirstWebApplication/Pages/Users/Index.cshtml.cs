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

namespace MyFirstWebApplication.Pages.Users
{
    [Authorize(Roles = "admin")]
    public class IndexModel : PageModel
    {
        private readonly MyFirstWebApplication.Data.ApplicationContext _context;

        public IndexModel(MyFirstWebApplication.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.Users
                .Include(u => u.Role)
                .ToListAsync();
        }
    }
}
