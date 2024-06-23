using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public CategoryService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // bağlantı
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // veritabanı
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName); // tablo
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName); // tablo
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryID == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var value = await _categoryCollection.Find(x => x.CategoryID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(value);
        }

        public async Task<List<ResultCategoryWithProductCountDto>> GetCategoryWithProductCount()
        {
            var categoryList = await _categoryCollection.Find(x => true).ToListAsync();
            var productListCount = await _productCollection.Aggregate().Group(x => x.CategoryID, y => new ResultCategoryWithProductCountDto
            {
                CategoryID = y.Key,
                ProductCount = y.Count()
            }).ToListAsync();
            foreach (var item in productListCount)
            {
                var value = await _categoryCollection.Find(x => x.CategoryID == item.CategoryID).FirstOrDefaultAsync();
                item.CategoryName = value.CategoryName;
                item.CategoryImage = value.CategoryImage;
            };


            return productListCount;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryID, value);
        }
    }
}
