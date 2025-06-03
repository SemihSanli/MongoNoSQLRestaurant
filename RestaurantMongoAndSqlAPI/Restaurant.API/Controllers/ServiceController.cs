using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTO.ServiceDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _servicesService;

        public ServiceController(IServicesService ServiceService)
        {
            _servicesService = ServiceService;
        }
        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _servicesService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateService(CreateServiceDTO createServiceDTO)
        {
            Service service = new Service()
            {
                ServiceTitle = createServiceDTO.ServiceTitle,
                ServiceArticle = createServiceDTO.ServiceArticle,
                ServiceMinDescription = createServiceDTO.ServiceMinDescription,
                ServicePrice = createServiceDTO.ServicePrice,
                ServiceSubTitle = createServiceDTO.ServiceSubTitle,
                ServiceImageURL = createServiceDTO.ServiceImageURL,
            };
            _servicesService.TInsert(service);
            return Ok("Hakkımda Kısmı Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteService(string id)
        {
            _servicesService.TDelete(id);
            return Ok("Hakkımda başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDTO updateServiceDTO)
        {
            Service service = new Service()
            {
                Id = updateServiceDTO.Id,
                ServiceTitle = updateServiceDTO.ServiceTitle,
                ServiceArticle = updateServiceDTO.ServiceArticle,
                ServiceMinDescription = updateServiceDTO.ServiceMinDescription,
                ServicePrice = updateServiceDTO.ServicePrice,
                ServiceSubTitle = updateServiceDTO.ServiceSubTitle,
                ServiceImageURL= updateServiceDTO.ServiceImageURL,
            };
            _servicesService.TUpdate(service);
            return Ok("Hakkımda başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetServiceById(string id)
        {
            var values = _servicesService.TGetByID(id);
            return Ok(values);
        }
    }
}
