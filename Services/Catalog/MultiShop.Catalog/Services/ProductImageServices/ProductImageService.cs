using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productımage;
        private readonly IMapper mapper;
        public ProductImageService(IMapper mapper, IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);
            _productımage = database.GetCollection<ProductImage>(settings.ProductİmageCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateImageProductDtos createImageProductDtos)
        {
            var value = mapper.Map<ProductImage>(createImageProductDtos);
            await _productımage.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productımage.DeleteOneAsync(v => v.ID == id);
        }

        public async Task<List<ResultImageProductDtos>> GetAllProductImageAsync()
        {
            var values = await _productımage.Find(v => true).ToListAsync();
            return mapper.Map<List<ResultImageProductDtos>>(values);
        }

        public async Task<GetByIdImageProductDtos> GetByIdProductImageDto(string id)
        {
            var values = await _productımage.Find(v => v.ID == id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdImageProductDtos>(values);
        }

        public async Task UpdateProductImageAsync(UpdateImageProductDtos updateImage)
        {
            var values = mapper.Map<ProductImage>(updateImage);
            await _productımage.FindOneAndReplaceAsync(v => v.ID == updateImage.ID, values);
        }
    }
}
