using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTO.BookATableDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookATableController : ControllerBase
    {
        private readonly IBookATableService _BookATableService;

        public BookATableController(IBookATableService BookATableService)
        {
            _BookATableService = BookATableService;
        }

        [HttpGet]
        public IActionResult BookATableList()
        {
            var values = _BookATableService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBookATable(CreateBookATableDTO createBookATableDTO)
        {
            BookATable bookATable = new BookATable()
            {
                BookFullName = createBookATableDTO.BookFullName,
                BookDate = createBookATableDTO.BookDate,
                BookEmail = createBookATableDTO.BookEmail,
                BookMessage = createBookATableDTO.BookMessage,
                BookPersonCount = createBookATableDTO.BookPersonCount,
                BookPhone = createBookATableDTO.BookPhone,

            };
            _BookATableService.TInsert(bookATable);
            return Ok("Rezervasyon Kısmı Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBookATable(string id)
        {
            _BookATableService.TDelete(id);
            return Ok("Rezervasyon başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateBookATable(UpdateBookATableDTO updateBookATableDTO)
        {
            BookATable bookATable = new BookATable()
            {
                Id = updateBookATableDTO.Id,
                BookFullName = updateBookATableDTO.BookFullName,
                BookDate = updateBookATableDTO.BookDate,
                BookEmail = updateBookATableDTO.BookEmail,
                BookMessage = updateBookATableDTO.BookMessage,
                BookPersonCount = updateBookATableDTO.BookPersonCount,
                BookPhone = updateBookATableDTO.BookPhone,

            };
            _BookATableService.TUpdate(bookATable);
            return Ok("Rezervasyon başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetBookATableById(string id)
        {
            var values = _BookATableService.TGetByID(id);
            return Ok(values);
        }
    }
}
