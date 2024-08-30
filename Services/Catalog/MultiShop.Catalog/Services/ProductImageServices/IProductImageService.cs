using MultiShop.Catalog.Dtos.ProductImageDtos;
namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultImageProductDtos>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateImageProductDtos createImageProductDtos);
        Task UpdateProductImageAsync(UpdateImageProductDtos updateImage);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdImageProductDtos> GetByIdProductImageDto(string id);
    }
}
