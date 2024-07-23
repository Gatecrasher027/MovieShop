using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}