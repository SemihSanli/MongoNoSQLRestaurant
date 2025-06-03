using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTO.ProductDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDTO createProductDTO)
        {
            Product product = new Product()
            {
                ProductName = createProductDTO.ProductName,
                ProducContent = createProductDTO.ProducContent,
                ProductPrice = createProductDTO.ProductPrice,
                ProductImageURL = createProductDTO.ProductImageURL,
                CategoryId = createProductDTO.CategoryId
            };
            _productService.TInsert(product);
            return Ok("Hakkımda Kısmı Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(string id)
        {
            _productService.TDelete(id);
            return Ok("Hakkımda başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            Product product = new Product()
            {
                Id = updateProductDTO.Id,
                ProductName = updateProductDTO.ProductName,
                ProducContent = updateProductDTO.ProducContent,
                ProductPrice = updateProductDTO.ProductPrice,
                ProductImageURL = updateProductDTO.ProductImageURL,
                CategoryId = updateProductDTO.CategoryId
            };
            _productService.TUpdate(product);
            return Ok("Hakkımda başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(string id)
        {
            var values = _productService.TGetByID(id);
            return Ok(values);
        }
        [HttpGet("Category/{categoryId}")]
        public async Task<IActionResult> GetProductByCategory(string categoryId)
        {
           var values = await _productService.GetProductByCategoryIdAsync(categoryId);
            return Ok(values);
        }
    }
}
