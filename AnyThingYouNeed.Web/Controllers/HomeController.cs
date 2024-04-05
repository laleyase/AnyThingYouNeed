using AnyThingYouNeed.Bussiness.Abstract;
using AnyThingYouNeed.Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace AnyThingYouNeed.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRequestService _requestService;
        public HomeController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult MakeRequest(Request model)
        {

            var addedRequest = _requestService.AddRequest(model);
            if (addedRequest.Success == true)
            {
                return Json(addedRequest.Message);
            }
            else
            {
                return Json(addedRequest.Message);
            }

        }


    }
}
