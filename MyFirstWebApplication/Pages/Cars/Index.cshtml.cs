﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFirstWebApplication.Data;
using MyFirstWebApplication.Models;

namespace MyFirstWebApplication.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly MyFirstWebApplication.Data.UserContext _context;

        public IndexModel(MyFirstWebApplication.Data.UserContext context)
        {
            _context = context;
        }

        public IList<ArticleModel> ArticleModel { get;set; }

        public async Task OnGetAsync()
        {
            ArticleModel = await _context.ArticleModels.ToListAsync();
        }
    }
}
