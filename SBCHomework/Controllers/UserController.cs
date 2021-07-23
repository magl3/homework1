using Microsoft.AspNetCore.Mvc;
using SBCHomework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBCHomework.Controllers
{
    public class UserController : Controller
    {
        private readonly BootCampDbContext dbContext;

        public UserController(BootCampDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var users = dbContext.Users.ToList();
            if (User.Identity.IsAuthenticated)
            {
                users = users.Where(x => x.Email != User.Identity.Name && x.ShowAcc == true).ToList();
            }
            return View(users);
        }
    }
}
