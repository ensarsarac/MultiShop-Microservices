using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Service.ContactServices
{
    public class ContactService:IContactService
    {
        private readonly IMongoCollection<Contact> _ContactCollection;
        private readonly IMapper _mapper;

        public ContactService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // bağlantı
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // veritabanı
            _ContactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName); // tablo
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            await _ContactCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _ContactCollection.DeleteOneAsync(x => x.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _ContactCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var value = await _ContactCollection.Find(x => x.ContactId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(value);
        }


        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            await _ContactCollection.FindOneAndReplaceAsync(x => x.ContactId == updateContactDto.ContactId, value);
        }
    }
}
