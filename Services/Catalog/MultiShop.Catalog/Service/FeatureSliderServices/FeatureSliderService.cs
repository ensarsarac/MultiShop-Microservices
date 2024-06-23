
using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Service.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _featureSliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(x=>x.FeatureSliderId == id);
        }

        public async Task FeatureSliderChangeStatusToFalse(string id)
        {
            var value = await _featureSliderCollection.Find(x => x.FeatureSliderId == id).FirstAsync();
            value.Status = false;
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == value.FeatureSliderId, value);
        }

        public async Task FeatureSliderChangeStatusToTrue(string id)
        {
            var value = await _featureSliderCollection.Find(x => x.FeatureSliderId == id).FirstAsync();
            value.Status = true;
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == value.FeatureSliderId, value);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var values = await _featureSliderCollection.Find(x=>true).ToListAsync();
            var result = _mapper.Map<List<ResultFeatureSliderDto>>(values);
            return result;
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var value = await _featureSliderCollection.Find(x=>x.FeatureSliderId==id).FirstAsync();
            return _mapper.Map<GetByIdFeatureSliderDto>(value);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == updateFeatureSliderDto.FeatureSliderId, value);
        }
    }
}
