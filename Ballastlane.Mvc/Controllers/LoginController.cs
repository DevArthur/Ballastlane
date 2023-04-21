using Ballastlane.Data.Models.Entities;
using Ballastlane.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ballastlane.Mvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IRepository<User> _repository;

        public LoginController(ILoginRepository loginRepository,
            IRepository<User> repository)
        {
            _loginRepository = loginRepository;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserCreated()
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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            var userExists = _loginRepository.Login(user.Email, user.Password);
            if (!userExists)
            {
                _repository.Create(user);
                _repository.Save();
                return RedirectToAction("Index", "Login");
            }
            TempData["message"] = "User or password invalid, please try again.";
            return RedirectToAction("Index", "Login");
        }
    }
}
