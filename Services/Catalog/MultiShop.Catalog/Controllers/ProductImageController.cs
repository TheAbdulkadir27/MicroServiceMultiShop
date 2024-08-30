using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;
namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;
        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductImageList()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageByID(string id)
        {
            var value = await _productImageService.GetByIdProductImageDto(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateImageProductDtos createImageproduct)
        {
            await _productImageService.CreateProductImageAsync(createImageproduct);
            return Ok("Ürün Resmi Başarıyla Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateImageProductDtos updateproductImages)
        {
            await _productImageService.UpdateProductImageAsync(updateproductImages);
            return Ok("Ürün Resmi Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün Resmi Başarıyla silindi");
        }
    }
}
