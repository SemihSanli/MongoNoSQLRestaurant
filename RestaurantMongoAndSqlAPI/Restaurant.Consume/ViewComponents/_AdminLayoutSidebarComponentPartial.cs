using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Consume.ViewComponents
{
    public class _AdminLayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
