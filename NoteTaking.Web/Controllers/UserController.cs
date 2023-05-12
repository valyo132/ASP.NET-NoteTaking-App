using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using NoteTaking.Data.Models;
using NoteTaking.Services.Interfaces;

namespace NoteTaking.Web.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// An instance of UserService.
        /// </summary>
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = GetCurrentUser();
            return View(user);
        }

        private ApplicationUser GetCurrentUser()
        {
            var userId = User.Identity.GetUserId();
            return _userService.GetUserById(userId);
        }
    }
}
