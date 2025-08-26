using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Person.Mvc.Models;

namespace Web.Person.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => RedirectToAction("Index", "People");

        public IActionResult Privacy() => RedirectToAction("Index", "People");

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
