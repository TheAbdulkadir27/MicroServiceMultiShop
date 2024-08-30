using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDto;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productdetails;
        private readonly IMapper _mapper;
        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionStrings);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productdetails = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectioName);
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productdetails.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productdetails.DeleteOneAsync(v => v.ID == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var value = await _productdetails.Find(v => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(value);
        }

        public async Task<GetByIDProductDetailDto> GetByIdProductDetailDto(string id)
        {
            var value = await _productdetails.Find(v => v.ID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDProductDetailDto>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateproductdetailDto)
        {
            var values = _mapper.Map<ProductDetail>(updateproductdetailDto);
            await _productdetails.FindOneAndReplaceAsync(v => v.ID == updateproductdetailDto.ID, values);
        }
    }
}
