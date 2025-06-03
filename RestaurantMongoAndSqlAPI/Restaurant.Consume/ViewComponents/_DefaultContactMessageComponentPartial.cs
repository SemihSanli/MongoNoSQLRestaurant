using Microsoft.AspNetCore.Mvc;
using Restaurant.DTO.ContactUsDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.Consume.ViewComponents
{
    public class _DefaultContactMessageComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new CreateContactUsDTO();
            return View(model);
        }
    }
}
