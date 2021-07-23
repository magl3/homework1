using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBCHomework.Contexts;
using SBCHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SBCHomework.Controllers
{
    public class OptionsController : Controller
    {
        private readonly BootCampDbContext dbContext;

        public OptionsController(BootCampDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Email == User.Identity.Name);

            return View(new OptionsViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                ShowAcc = user.ShowAcc,
                UniqKey = user.UniqKey,
            });
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(OptionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = dbContext.Users.FirstOrDefault(x => x.Email == User.Identity.Name);

                if (user.Email != model.Email)
                {
                    if (!dbContext.Users.Any(x => x.Email == model.Email))
                    {
                        user.Email = model.Email;
                    }
                    else
                    {
                        ModelState.AddModelError("", "UserName is already taken!");
                    }
                }

                user.ShowAcc = model.ShowAcc;
                user.UserName = model.UserName;
                user.Password = model.Password;

                dbContext.SaveChanges();
            }

            await Authenticate(model.Email);

            return RedirectToAction("Index", "Options");
        }
        private async Task Authenticate(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
