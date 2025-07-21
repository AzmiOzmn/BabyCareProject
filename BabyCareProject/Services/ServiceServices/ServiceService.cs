using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.DataAccess.Settings;
using BabyCareProject.Dtos.ServiceDtos;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCareProject.Services.ServiceServices
{
    public class ServiceService : IServiceService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Service> _serviceCollection;
        public ServiceService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
           _mapper = mapper;
            var mongoClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            _serviceCollection = mongoDatabase.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }
        public Task CreateAsync(CreateServiceDto createServiceDto)
        {
           var values = _mapper.Map<Service>(createServiceDto);
           return _serviceCollection.InsertOneAsync(values);
        }

        public async Task DeleteAsync(string id)
        {
         await _serviceCollection.DeleteOneAsync(x => x.ServiceId == id);
        }

        public async Task<List<ResultServiceDto>> GetAllAsync()
        {
           var values = await _serviceCollection.AsQueryable().ToListAsync();
           return _mapper.Map<List<ResultServiceDto>>(values);
        }

        public async Task<UpdateServiceDto> GetByIdAsync(string id)
        {
           var value = await _serviceCollection.Find(x => x.ServiceId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateServiceDto>(value);
        }

        public Task UpdateAsync(UpdateServiceDto updateServiceDto)
        {
            var service = _mapper.Map<Service>(updateServiceDto);
            return _serviceCollection.FindOneAndReplaceAsync(x => x.ServiceId == service.ServiceId, service);
        }
    }
}
