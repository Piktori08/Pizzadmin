using Pizzadmin.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Pizzadmin.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public UserController(IUserService userService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var usersToReturn = await _userService.GetUsersAsync();
            ViewData["active"] = "users";
            return View(usersToReturn);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var UserId = _signInManager.UserManager.GetUserId(User);
            var thisuser = _userManager.Users.SingleOrDefault(i => i.Id == UserId);

            try
            {
                if (user != null && user.Id != thisuser?.Id)
                {
                    await _userManager.DeleteAsync(user);
                };

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
