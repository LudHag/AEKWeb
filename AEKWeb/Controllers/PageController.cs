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
            ViewData["Canonical"] = "https://www.aelterekamereren.org";
            return View();
        }
        [Route("Calendar")]
        public IActionResult Calendar()
        {

            var events = dbContext.Events
                .Where(x => x.Date >= DateTime.Now.Date)
                .OrderBy(x => x.Date);

            var model = new CalendarViewModel(events);
            ViewData["Canonical"] = "https://www.aelterekamereren.org/calendar";

            return View(model);
        }
        [Route("Files")]
        public IActionResult Files()
        {
            var loggedIn = User.Identity.IsAuthenticated;
            var model = new FilesViewModel(loggedIn,
                new List<string>() {
                    "Altsax1",
                    "Altsax2",
                    "Banjo",
                    "Flöjt",
                    "Horn2",
                    "Klarinett1",
                    "Klarinett2",
                    "Klarinett3",
                    "Tenorsax",
                    "Trombon1",
                    "Trombon2",
                    "Trombon3",
                    "Trumpet1",
                    "Trumpet2",
                    "Trumpet3",
                    "Tuba"
                });
            ViewData["Canonical"] = "https://www.aelterekamereren.org/files";
            return View(model);
        }
        [Route("Contact")]
        public IActionResult Contact()
        {
            IEnumerable<SignUp> signups = new List<SignUp>();
            if (User.IsInRole("Styrelse"))
            {
                signups = dbContext.SignUps.OrderBy(x => x.SignupDate);

            }
            var model = new ContactViewModel(signups);
            ViewData["Canonical"] = "https://www.aelterekamereren.org/contact";
            return View(model);
        }

    }
}
