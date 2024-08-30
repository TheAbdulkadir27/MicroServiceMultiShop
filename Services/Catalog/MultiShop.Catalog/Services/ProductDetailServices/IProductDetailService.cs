using MultiShop.Catalog.Dtos.ProductDetailDto;
namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateproductdetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIDProductDetailDto> GetByIdProductDetailDto(string id);
    }
}
