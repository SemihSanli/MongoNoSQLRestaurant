using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTO.LoginDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.Consume.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDtos loginDtos)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDtos.UserName, loginDtos.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("AboutList", "Abouts");
            }
            return View();
        }
    }
}
