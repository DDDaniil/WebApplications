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

namespace MyFirstWebApplication.Pages.Science
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly MyFirstWebApplication.Data.ApplicationContext _context;

        public IndexModel(MyFirstWebApplication.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IList<ArticleModel> ArticleModel { get;set; }

        public async Task OnGetAsync(string TopicId)
        {
            ArticleModel = await _context.ArticleModels.Where(t => t.TopicId == TopicId).ToListAsync();
        }
    }
}
