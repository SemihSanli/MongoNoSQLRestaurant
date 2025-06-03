using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Consume.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
