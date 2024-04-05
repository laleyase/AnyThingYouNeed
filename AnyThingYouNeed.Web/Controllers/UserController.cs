using AnyThingYouNeed.Bussiness.Abstract;
using AnyThingYouNeed.Bussiness.Concrate.RequestModel;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExperienceIst.Wep.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(LoginRequestModel loginRequest)
        {
            var result = _userService.Login(loginRequest);
            if (result.Success == true)
            {
                //HttpContext.Response.Headers.TryAdd("Authorization", result.Token.JWT);
                Response.Cookies.Append("JWTToken", result.Token.JWT, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    MaxAge = TimeSpan.FromMinutes(20)
                });
                return Json(result.Message);
            }
            else
            {
                return Json(result.Message);
            }
        }

    }
}