using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Consume.ViewComponents
{
    public class _AdminLayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
