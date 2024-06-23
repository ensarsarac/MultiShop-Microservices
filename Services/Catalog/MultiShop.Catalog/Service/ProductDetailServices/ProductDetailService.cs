using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailsService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailsCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailsCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailsCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailsCollection.DeleteOneAsync(x => x.ProductDetailID == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productDetailsCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var value = await _productDetailsCollection.Find(x => x.ProductDetailID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(value);
        }

		public async Task<GetByIdProductDetailDto> GetByIdProductDetailByProductIdAsync(string id)
		{
			var value = await _productDetailsCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdProductDetailDto>(value);
		}

		public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailsCollection.FindOneAndReplaceAsync(x=>x.ProductDetailID==updateProductDetailDto.ProductDetailID, value);
        }
    }
}
