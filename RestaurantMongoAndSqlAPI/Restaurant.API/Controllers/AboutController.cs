using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTO.AboutDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDTO createAboutDTO)
        {
            About about = new About()
            {
                AboutTitle = createAboutDTO.AboutTitle,
                AboutSubTitle = createAboutDTO.AboutSubTitle,
                AboutArticle = createAboutDTO.AboutArticle,
                AboutDescription = createAboutDTO.AboutDescription,
                AboutImageURL = createAboutDTO.AboutImageURL,
            };
            _aboutService.TInsert(about);
            return Ok("Hakkımda Kısmı Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(string id)
        {
            _aboutService.TDelete(id);
            return Ok("Hakkımda başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            About about = new About()
            {
                Id = updateAboutDTO.Id,
                AboutTitle = updateAboutDTO.AboutTitle,
                AboutSubTitle = updateAboutDTO.AboutSubTitle,
                AboutArticle = updateAboutDTO.AboutArticle,
                AboutDescription = updateAboutDTO.AboutDescription,
                AboutImageURL = updateAboutDTO.AboutImageURL,
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımda başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAboutById(string id)
        {
            var values = _aboutService.TGetByID(id);
            return Ok(values);
        }
    }
}
