using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTO.OurSpecialDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurSpecialController : ControllerBase
    {
        private readonly IOurSpecialService _ourSpecialService;

        public OurSpecialController(IOurSpecialService OurSpecialService)
        {
            _ourSpecialService = OurSpecialService;
        }
        [HttpGet]
        public IActionResult OurSpecialList()
        {
            var values = _ourSpecialService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateOurSpecial(CreateOurSpecialDTO createOurSpecialDTO)
        {
            OurSpecial ourSpecial = new OurSpecial()
            {
               OurSpecialColumnTitle = createOurSpecialDTO.OurSpecialColumnTitle,
                OurSpecialContent = createOurSpecialDTO.OurSpecialContent,
                OurSpecialTitle = createOurSpecialDTO.OurSpecialTitle,
                OurSpecialImageURL = createOurSpecialDTO.OurSpecialImageURL,
            };
            _ourSpecialService.TInsert(ourSpecial);
            return Ok("Hakkımda Kısmı Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOurSpecial(string id)
        {
            _ourSpecialService.TDelete(id);
            return Ok("Hakkımda başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateOurSpecial(UpdateOurSpecialDTO updateOurSpecialDTO)
        {
            OurSpecial ourSpecial = new OurSpecial()
            {
                Id = updateOurSpecialDTO.Id,
                OurSpecialColumnTitle = updateOurSpecialDTO.OurSpecialColumnTitle,
                OurSpecialContent = updateOurSpecialDTO.OurSpecialContent,
                OurSpecialTitle = updateOurSpecialDTO.OurSpecialTitle,
                OurSpecialImageURL = updateOurSpecialDTO.OurSpecialImageURL,
            };
            _ourSpecialService.TUpdate(ourSpecial);
            return Ok("Hakkımda başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetOurSpecialById(string id)
        {
            var values = _ourSpecialService.TGetByID(id);
            return Ok(values);
        }
    }
}
