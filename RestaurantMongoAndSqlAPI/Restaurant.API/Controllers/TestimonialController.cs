using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTO.TestimonialDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialTestimonial;

        public TestimonialController(ITestimonialService TestimonialTestimonial)
        {
            _testimonialTestimonial = TestimonialTestimonial;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialTestimonial.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDTO createTestimonialDTO)
        {
            Testimonial testimonial = new Testimonial()
            {
                TestimonialFullName = createTestimonialDTO.TestimonialFullName,
                TestimonialImageURL = createTestimonialDTO.TestimonialImageURL,
                TestimonialComment = createTestimonialDTO.TestimonialComment,
                TestimonialTitle = createTestimonialDTO.TestimonialTitle
            };
            _testimonialTestimonial.TInsert(testimonial);
            return Ok("Hakkımda Kısmı Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(string id)
        {
            _testimonialTestimonial.TDelete(id);
            return Ok("Hakkımda başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO updateTestimonialDTO)
        {
            Testimonial testimonial = new Testimonial()
            {
                Id = updateTestimonialDTO.Id,
                TestimonialFullName = updateTestimonialDTO.TestimonialFullName,
                TestimonialImageURL = updateTestimonialDTO.TestimonialImageURL,
                TestimonialComment = updateTestimonialDTO.TestimonialComment,
                TestimonialTitle = updateTestimonialDTO.TestimonialTitle
            };
            _testimonialTestimonial.TUpdate(testimonial);
            return Ok("Hakkımda başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonialById(string id)
        {
            var values = _testimonialTestimonial.TGetByID(id);
            return Ok(values);
        }
    }
}
