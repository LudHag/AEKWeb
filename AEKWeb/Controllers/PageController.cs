using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
        [Route("Files")]
        public IActionResult Files()
        {
            return View();
        }
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

    }
}
