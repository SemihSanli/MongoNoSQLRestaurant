using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Consume.Controllers
{
    public class ErrorPage : Controller
    {
        public IActionResult NotFount404()
        {
            return View();
        }
    }
}
