using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Service.SpecialOfferServices
{
	public class SpecialOfferService : ISpecialOfferService
	{
		private readonly IMongoCollection<SpecialOffer> _mongoCollection;
		private readonly IMapper _mapper;

		public SpecialOfferService(IMapper mapper,IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_mongoCollection = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
			_mapper = mapper;
		}

		public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
		{
			var value = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
			await _mongoCollection.InsertOneAsync(value);
		}

		public async Task DeleteSpecialOfferAsync(string id)
		{
			await _mongoCollection.DeleteOneAsync(x=>x.SpecialOfferId==id);
		}

		public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
		{
			return _mapper.Map<List<ResultSpecialOfferDto>>(await _mongoCollection.Find(x=>true).ToListAsync());
		}

		public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
		{
			return _mapper.Map<GetByIdSpecialOfferDto>(await _mongoCollection.Find(x=>x.SpecialOfferId==id).FirstAsync());
		}

		public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
		{
			var value = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
			await _mongoCollection.FindOneAndReplaceAsync(x=>x.SpecialOfferId==updateSpecialOfferDto.SpecialOfferId, value);
		}
	}
}
