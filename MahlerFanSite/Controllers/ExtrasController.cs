using Microsoft.AspNetCore.Mvc;

namespace MahlerFanSite.Controllers
{
    public class ExtrasController : Controller
    {
        public IActionResult Index() => View();

        [HttpPost]
        public RedirectResult Index(string url) => Redirect(url);

        public BadRequestResult Bad() => BadRequest();

        public JsonResult Json()
        {
            // I am creating a dynamic object, similar to JavaScript's object
            dynamic json = new
            {
                UserId = 1,
                UserName = "John",
                Company = "Google",
                Salary = 500
            };
            return Json(json);
        }

        public string GetString() => "This is just a plain old boring string and nothing more!";
    }
}
