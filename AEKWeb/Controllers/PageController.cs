using AEKWeb.Data;
using AEKWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AEKWeb.Controllers
{

    public class PageController : Controller
    {
        private readonly AEKContext dbContext;

        public PageController(AEKContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Calendar")]
        public IActionResult Calendar()
        {

            var events = dbContext.Events
                .Where(x => x.Date >= DateTime.Now.Date)
                .OrderBy(x => x.Date);

            var model = new CalendarModel(events);

            return View(model);
        }
        [Route("Files")]
        public IActionResult Files()
        {
            var loggedIn = User.Identity.IsAuthenticated;
            var model = new FilesModel(loggedIn, new List<string>() { "Flöjt", "Trombon" });
            return View(model);
        }
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

    }
}
