using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTO.CategoryDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            Category Category = new Category()
            {
                CategoryName = createCategoryDTO.CategoryName,
               
            };
            _categoryService.TInsert(Category);
            return Ok("Kategori Kısmı Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(string id)
        {
            _categoryService.TDelete(id);
            return Ok("Kategori başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            Category Category = new Category()
            {
                Id = updateCategoryDTO.Id,
                CategoryName = updateCategoryDTO.CategoryName,
             
            };
            _categoryService.TUpdate(Category);
            return Ok("Kategori başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(string id)
        {
            var values = _categoryService.TGetByID(id);
            return Ok(values);
        }
    }
}
