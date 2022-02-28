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
    public class DetailsModel : PageModel
    {
        private readonly MyFirstWebApplication.Data.UserContext _context;

        public DetailsModel(MyFirstWebApplication.Data.UserContext context)
        {
            _context = context;
        }

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
    }
}
