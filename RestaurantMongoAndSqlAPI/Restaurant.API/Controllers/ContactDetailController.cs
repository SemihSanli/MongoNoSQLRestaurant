using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTO.ContactDetailDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailController : ControllerBase
    {
        private readonly IContactDetailService _contactDetailService;

        public ContactDetailController(IContactDetailService ContactDetailService)
        {
            _contactDetailService = ContactDetailService;
        }
        [HttpGet]
        public IActionResult ContactDetailList()
        {
            var values = _contactDetailService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContactDetail(CreateContactDetailDTO createContactDetailDTO)
        {
            ContactDetail contactDetail = new ContactDetail()
            {
                ContactDetailCallUs = createContactDetailDTO.ContactDetailCallUs,
                ContactDetailEmailUs = createContactDetailDTO.ContactDetailEmailUs,
                ContactDetailLocation = createContactDetailDTO.ContactDetailLocation,
                ContactDetailOpenHours = createContactDetailDTO.ContactDetailOpenHours,
                ContactDetailLocationMapURL = createContactDetailDTO.ContactDetailLocation,
            };
            _contactDetailService.TInsert(contactDetail);
            return Ok("Hakkımda Kısmı Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContactDetail(string id)
        {
            _contactDetailService.TDelete(id);
            return Ok("Hakkımda başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateContactDetail(UpdateContactDetailDTO updateContactDetailDTO)
        {
            ContactDetail contactDetail = new ContactDetail()
            {
                Id = updateContactDetailDTO.Id,
                ContactDetailCallUs = updateContactDetailDTO.ContactDetailCallUs,
                ContactDetailEmailUs = updateContactDetailDTO.ContactDetailEmailUs,
                ContactDetailLocation = updateContactDetailDTO.ContactDetailLocation,
                ContactDetailOpenHours = updateContactDetailDTO.ContactDetailOpenHours,
                ContactDetailLocationMapURL = updateContactDetailDTO.ContactDetailLocationMapURL,
            };
            _contactDetailService.TUpdate(contactDetail);
            return Ok("Hakkımda başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetContactDetailById(string id)
        {
            var values = _contactDetailService.TGetByID(id);
            return Ok(values);
        }
    }
}
