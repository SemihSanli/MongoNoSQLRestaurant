using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTO.ContactUsDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService ContactUsService)
        {
            _contactUsService = ContactUsService;
        }
        [HttpGet]
        public IActionResult ContactUsList()
        {
            var values = _contactUsService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContactUs(CreateContactUsDTO createContactUsDTO)
        {
            ContactUs contactUs = new ContactUs()
            {
                ContactUsEmail = createContactUsDTO.ContactUsEmail,
                ContactUsFullName = createContactUsDTO.ContactUsFullName,
                ContactUsMessage = createContactUsDTO.ContactUsMessage,
                ContactUsSubject = createContactUsDTO.ContactUsSubject,
            };
            _contactUsService.TInsert(contactUs);
            return Ok("Hakkımda Kısmı Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContactUs(string id)
        {
            _contactUsService.TDelete(id);
            return Ok("Hakkımda başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateContactUs(UpdateContactUsDTO updateContactUsDTO)
        {
            ContactUs contactUs = new ContactUs()
            {
                Id = updateContactUsDTO.Id,
                ContactUsEmail = updateContactUsDTO.ContactUsEmail,
                ContactUsFullName = updateContactUsDTO.ContactUsFullName,
                ContactUsMessage = updateContactUsDTO.ContactUsMessage,
                ContactUsSubject = updateContactUsDTO.ContactUsSubject,
            };
            _contactUsService.TUpdate(contactUs);
            return Ok("Hakkımda başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetContactUsById(string id)
        {
            var values = _contactUsService.TGetByID(id);
            return Ok(values);
        }
    }
}
