using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Service.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _features;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public FeatureService(IMapper mapper,IDatabaseSettings databaseSettings,IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(_configuration.GetSection("DatabaseSettings").GetSection("ConnectionString").Value);
            var database = client.GetDatabase(_configuration.GetSection("DatabaseSettings:DatabaseName").Value);
            _features = database.GetCollection<Feature>(_configuration.GetSection("DatabaseSettings:FeatureCollectionName").Value);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            await _features.InsertOneAsync(value);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _features.DeleteOneAsync(x => x.FeatureId == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var values = await _features.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var value = await _features.Find(x => x.FeatureId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureDto>(value);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            await _features.FindOneAndReplaceAsync(x => x.FeatureId == updateFeatureDto.FeatureId, value);
        }
    }
}
