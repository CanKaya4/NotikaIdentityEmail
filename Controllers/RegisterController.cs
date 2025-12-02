using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotikaIdentityEmail.Entities;
using NotikaIdentityEmail.Models;

namespace NotikaIdentityEmail.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterUserViewModel registerUserViewModel)
        {
            AppUser appUser = new AppUser()
            {
                Name = registerUserViewModel.Name,
                Email = registerUserViewModel.Email,
                Surname = registerUserViewModel.Surname,
                UserName = registerUserViewModel.UserName
            };
            var result = await _userManager.CreateAsync(appUser, registerUserViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("UserLogin", "LoginController");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
