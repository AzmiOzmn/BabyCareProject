using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.DataAccess.Settings;
using BabyCareProject.Dtos.HeroDtos;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCareProject.Services.HeroServices
{
    public class HeroService: IHeroService



    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Hero> _heroCollection;

   

        public HeroService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var mongoClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            _heroCollection = mongoDatabase.GetCollection<Hero>(databaseSettings.HeroCollectionName);
        }

        public Task CreateHeroAsync(CreateHeroDto createHeroDto)
        {
            var hero = _mapper.Map<Hero>(createHeroDto);
            return _heroCollection.InsertOneAsync(hero);

        }

        public async Task DeleteHeroAsync(string id)
        {
         await _heroCollection.DeleteOneAsync(x => x.HeroId == id);
        }

        public async Task<List<ResultHeroDto>> GetAllAsync()
        {
            var values = _heroCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultHeroDto>>(await values);
        }

        public async Task<UpdateHeroDto> GetById(string id)
        {
           var value = _heroCollection.Find(x => x.HeroId == id).FirstOrDefaultAsync();
           return _mapper.Map<UpdateHeroDto>(value); 
        }

        public Task UpdateHeroAsync(UpdateHeroDto updateHeroDto)
        {
            var hero = _mapper.Map<Hero>(updateHeroDto);
            return _heroCollection.FindOneAndReplaceAsync(x => x.HeroId == hero.HeroId, hero);

        }
    }
}
