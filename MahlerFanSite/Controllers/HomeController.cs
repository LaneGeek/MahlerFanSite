using Microsoft.AspNetCore.Mvc;

namespace MahlerFanSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult History() => View();

        public IActionResult Stories() => View();
    }
}
