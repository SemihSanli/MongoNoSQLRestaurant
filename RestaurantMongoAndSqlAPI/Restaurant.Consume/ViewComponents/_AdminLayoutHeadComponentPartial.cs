using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Consume.ViewComponents
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
