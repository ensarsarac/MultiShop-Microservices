using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productsCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productsCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productsCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productsCollection.DeleteOneAsync(x=>x.ProductID == id);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllListProductOrderByIdAsync()
        {
            var values = await _productsCollection.Find(x => true).SortByDescending(x => x.ProductID).ToListAsync();
            var result =  _mapper.Map<List<ResultProductWithCategoryDto>>(values);
            foreach (var item in result)
            {
                var category = await _categoryCollection.Find<Category>(x => x.CategoryID == item.CategoryID).FirstAsync();
                item.CategoryName = category.CategoryName;
            }
            return result;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values =await _productsCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<List<ResultProductDto>> GetAllProductByCategoryId(string id)
        {
            var values = await _productsCollection.Find(x => x.CategoryID == id).ToListAsync();
            var result = _mapper.Map<List<ResultProductDto>>(values);
            return result;
        }

        public async Task<List<ResultProductDto>> GetAllProductOrderByIdAsync()
        {
            var values = await _productsCollection.Find(x => true).SortByDescending(x => x.ProductID).Limit(8).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            var values = await _productsCollection.Find(x=>true).ToListAsync();
            var result = _mapper.Map<List<ResultProductWithCategoryDto>>(values);
            foreach (var item in result)
            {
                var category = await _categoryCollection.Find<Category>(x => x.CategoryID == item.CategoryID).FirstAsync();
                item.CategoryName = category.CategoryName;
            }
            return result;
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productsCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task<ResultProductWithCategoryDto> GetByIdProductWithCategoryAsync(string id)
        {
            var value = await _productsCollection.Find(x=>x.ProductID == id).FirstOrDefaultAsync();
            var result = _mapper.Map<ResultProductWithCategoryDto>(value);
            var category = await _categoryCollection.Find(x => x.CategoryID == result.CategoryID).FirstOrDefaultAsync();
            result.CategoryName = category.CategoryName;
            return result;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productsCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, value);
        }
    }
}
