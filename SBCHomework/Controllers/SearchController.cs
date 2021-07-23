using Microsoft.AspNetCore.Mvc;
using SBCHomework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBCHomework.Controllers
{
    public class SearchController : Controller
    {
        private readonly BootCampDbContext dbContext;

        public SearchController(BootCampDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task <IActionResult> Index(string SearchStr)
        {
            var users = from m in dbContext.Users
                        select m;
            if (!String.IsNullOrEmpty(SearchStr))
            {
                users = users.Where(s => s.UniqKey.ToString().Contains(SearchStr));
            }
            return View(users.ToList());
        }
    }
}
