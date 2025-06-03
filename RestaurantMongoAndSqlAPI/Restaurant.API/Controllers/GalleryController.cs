using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTO.GalleryDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService GalleryService)
        {
            _galleryService = GalleryService;
        }
        [HttpGet]
        public IActionResult GalleryList()
        {
            var values = _galleryService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateGallery(CreateGalleryDTO createGalleryDTO)
        {
            Gallery gallery = new Gallery()
            {
                GalleryImageURL = createGalleryDTO.GalleryImageURL
            };
            _galleryService.TInsert(gallery);
            return Ok("Hakkımda Kısmı Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGallery(string id)
        {
            _galleryService.TDelete(id);
            return Ok("Hakkımda başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateGallery(UpdateGalleryDTO updateGalleryDTO)
        {
            Gallery gallery = new Gallery()
            {
                Id = updateGalleryDTO.Id,
                GalleryImageURL = updateGalleryDTO.GalleryImageURL
            };
            _galleryService.TUpdate(gallery);
            return Ok("Hakkımda başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetGalleryById(string id)
        {
            var values = _galleryService.TGetByID(id);
            return Ok(values);
        }
    }
}
