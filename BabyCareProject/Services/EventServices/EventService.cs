using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.DataAccess.Settings;
using BabyCareProject.Dtos.EventDtos;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCareProject.Services.EventServices
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Event> _eventCollection;

        public EventService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var mongoClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            _eventCollection = mongoDatabase.GetCollection<Event>(databaseSettings.EventCollectionName);
        }
        public Task CreateAsync(CreateEventDto createEventDto)
        {
           var values = _mapper.Map<Event>(createEventDto);
           return _eventCollection.InsertOneAsync(values);
        }

        public async Task DeleteAsync(string id)
        {
            await _eventCollection.DeleteOneAsync(x => x.EventId == id);

        }

        public async Task<List<ResultEventDto>> GetAllAsync()
        {
            var values = await _eventCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultEventDto>>(values);
        }

        public async Task<UpdateEventDto> GetById(string id)
        {
           var value = await _eventCollection.Find(x => x.EventId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateEventDto>(value);
        }

        public async Task UpdateAsync(UpdateEventDto updateEventDto)
        {
            var product = _mapper.Map<Event>(updateEventDto);
            await _eventCollection.FindOneAndReplaceAsync(x => x.EventId == product.EventId, product);
        }
    }
}
