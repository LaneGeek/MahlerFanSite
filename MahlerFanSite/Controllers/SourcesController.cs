using Microsoft.AspNetCore.Mvc;

namespace MahlerFanSite.Controllers
{
    public class SourcesController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Books() =>View();

        public IActionResult Links() => View();
    }
}
