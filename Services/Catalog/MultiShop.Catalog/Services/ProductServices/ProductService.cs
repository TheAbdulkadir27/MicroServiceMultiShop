using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _mongoCollection;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionStrings);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mongoCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _mongoCollection.InsertOneAsync(value);
        }
        public async Task DeleteProductAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(v => v.ID == id);
        }

        public async Task<List<ResultProductDtos>> GetAllProductAsync()
        {
            var values = await _mongoCollection.Find(v => true).ToListAsync();
            return _mapper.Map<List<ResultProductDtos>>(values);
        }

        public async Task<GetByIDProductDto> GetByIdProductDto(string id)
        {
            var value = await _mongoCollection.Find(v => v.ID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDProductDto>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDto productDto)
        {
            var value = _mapper.Map<Product>(productDto);
            await _mongoCollection.FindOneAndReplaceAsync(v => v.ID == productDto.ID, value);
        }
    }
}
