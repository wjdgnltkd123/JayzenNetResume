using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Resume.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var users = await _userService.GetAllAsync();

            ViewBag.Users = users;

            return View();
        }
    }
}
