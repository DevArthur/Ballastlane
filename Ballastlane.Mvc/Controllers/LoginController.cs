using Ballastlane.Data.Models.Entities;
using Ballastlane.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ballastlane.Mvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            var isLoginSuccess = _loginRepository.Login(user.Email, user.Password);
            if (isLoginSuccess)
            {
                return RedirectToAction("Index", "Product");
            }
            TempData["loginError"] = "User or password invalid, please try again.";
            return RedirectToAction("Index", "Login");
        }
    }
}
