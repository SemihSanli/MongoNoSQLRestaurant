using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Consume.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
