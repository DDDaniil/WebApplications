using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFirstWebApplication.Data;
using MyFirstWebApplication.Models;

namespace MyFirstWebApplication.Pages.Account
{
    public class Lmodel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    [ValidateAntiForgeryToken]
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Lmodel Lmodel { get; set; }


        private ApplicationContext db;
        public LoginModel(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
                            /*.Include(u=>u.Role)*/
            if (ModelState.IsValid)
            {
                User user = await db.Users
                     .FirstOrDefaultAsync(u => u.Email == Lmodel.Email && u.Password == Lmodel.Password);
                if (user != null)
                {
                    await Authenticate(user); 

                    if(Request.Query.ContainsKey("ReturnUrl"))
                        return Redirect(Request.Query["ReturnUrl"]);
                    return RedirectToPage("/Index");

                    
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return Page();
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
              //  new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}