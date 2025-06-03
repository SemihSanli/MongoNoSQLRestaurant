using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Consume.ViewComponents
{
    public class _DefaultFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
