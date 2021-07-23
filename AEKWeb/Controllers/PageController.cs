using AEKWeb.Data;
using AEKWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AEKWeb.Controllers
{

    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("Calendar")]
        public IActionResult Calendar()
        {

            var model = new CalendarModel(new List<CalendarEvent>() {
                new CalendarEvent() {Date = DateTime.Now , Event = "Sola sig", Place ="Lund"},
                new CalendarEvent() {Date = DateTime.Now.AddYears(1) , Event = "Sola sig igen", Place ="Malmö"}
            });

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
