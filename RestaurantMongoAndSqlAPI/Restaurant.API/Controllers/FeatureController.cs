using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTO.FeatureDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService FeatureService)
        {
            _featureService = FeatureService;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _featureService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            Feature feature = new Feature()
            {
                FeatureSubTitle = createFeatureDTO.FeatureSubTitle,
                FeatureTitle = createFeatureDTO.FeatureTitle,
            };
            _featureService.TInsert(feature);
            return Ok("Hakkımda Kısmı Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(string id)
        {
            _featureService.TDelete(id);
            return Ok("Hakkımda başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            Feature feature = new Feature()
            {
                Id = updateFeatureDTO.Id,
                FeatureSubTitle = updateFeatureDTO.FeatureSubTitle,
                FeatureTitle = updateFeatureDTO.FeatureTitle,
            };
            _featureService.TUpdate(feature);
            return Ok("Hakkımda başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetFeatureById(string id)
        {
            var values = _featureService.TGetByID(id);
            return Ok(values);
        }
    }
}
