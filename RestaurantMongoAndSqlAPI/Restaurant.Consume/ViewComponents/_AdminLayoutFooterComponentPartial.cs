using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Consume.ViewComponents
{
    public class _AdminLayoutFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
