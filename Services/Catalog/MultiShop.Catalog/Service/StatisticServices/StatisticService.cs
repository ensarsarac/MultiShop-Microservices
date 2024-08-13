
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Service.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public StatisticService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // bağlantı
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // veritabanı
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }
        public async Task<int> BrandCount()
        {

            return (int) _brandCollection.CountDocuments(FilterDefinition<Brand>.Empty);
        }

        public async Task<int> CategoryCount()
        {
            return (int)_categoryCollection.CountDocuments(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxProductName()
        {
            var filter = Builders<Product>.Filter.Empty;

            var sort = Builders<Product>.Sort.Ascending(x=>x.ProductPrice);

            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductID");

            var result = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();

            return result.GetValue("ProductName").AsString;
        }

        public async Task<string> GetMinProductName()
        {
            var filter = Builders<Product>.Filter.Empty;

            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);

            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductID");

            var result = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();

            return result.GetValue("ProductName").AsString;
        }

        public async Task<decimal> ProductAvgPrice()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$group",new BsonDocument
                {
                    {"_id",null },
                    {"averagePrice", new BsonDocument("$avg","$ProductPrice") }
                })
            };

            var result =  await _productCollection.AggregateAsync<BsonDocument>(pipeline);

            var document =await result.FirstOrDefaultAsync();

            if (document == null || !document.Contains("averagePrice"))
            {
                return decimal.Zero;
            }

            var value = document["averagePrice"].ToDecimal();

            return value;
        }

        public async Task<int> ProductCount()
        {
            return (int)_productCollection.CountDocuments(FilterDefinition<Product>.Empty);
        }
    }
}
