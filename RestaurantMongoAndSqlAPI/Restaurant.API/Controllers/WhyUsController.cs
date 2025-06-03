using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTO.WhyUsDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhyUsController : ControllerBase
    {
        private readonly IWhyUsService _whyUsWhyUs;

        public WhyUsController(IWhyUsService WhyUsWhyUs)
        {
            _whyUsWhyUs = WhyUsWhyUs;
        }

        [HttpGet]
        public IActionResult WhyUsList()
        {
            var values = _whyUsWhyUs.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateWhyUs(CreateWhyUsDTO createWhyUsDTO)
        {
            WhyUs whyUs = new WhyUs()
            {
                WhyUsDetail = createWhyUsDTO.WhyUsDetail,
                WhyUsTitle = createWhyUsDTO.WhyUsTitle
            };
            _whyUsWhyUs.TInsert(whyUs);
            return Ok("Hakkımda Kısmı Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteWhyUs(string id)
        {
            _whyUsWhyUs.TDelete(id);
            return Ok("Hakkımda başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateWhyUs(UpdateWhyUsDTO updateWhyUsDTO)
        {
            WhyUs whyUs = new WhyUs()
            {
                Id = updateWhyUsDTO.Id,
                WhyUsDetail = updateWhyUsDTO.WhyUsDetail,
                WhyUsTitle = updateWhyUsDTO.WhyUsTitle
            };
            _whyUsWhyUs.TUpdate(whyUs);
            return Ok("Hakkımda başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetWhyUsById(string id)
        {
            var values = _whyUsWhyUs.TGetByID(id);
            return Ok(values);
        }
    }
}
