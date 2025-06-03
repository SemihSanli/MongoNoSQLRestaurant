using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTO.RegisterDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.Consume.Controllers
{
   
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDtos registerDtos)
        {
            var appUser = new AppUser()
            {
                FullName=registerDtos.Name,
                Email = registerDtos.Mail,
                UserName=registerDtos.Username
            };
            var result = await _userManager.CreateAsync(appUser, registerDtos.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
