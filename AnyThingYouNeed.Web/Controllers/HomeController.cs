using Microsoft.AspNetCore.Mvc;

namespace AnyThingYouNeed.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MakeRequest()
        {
            return View();
        }
    }
}
