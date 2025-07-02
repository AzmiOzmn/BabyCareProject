using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.DataAccess.Settings;
using BabyCareProject.Dtos.AboutDtos;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCareProject.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<About> _aboutCollection;

        public AboutService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
        }
        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
           var about = _mapper.Map<About>(createAboutDto);
           await _aboutCollection.InsertOneAsync(about);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(a=>a.AboutId ==id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
          var values = await _aboutCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto createAboutDto)
        {
            var about = _mapper.Map<About>(createAboutDto);
            await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutId == about.AboutId, about);
        }

        public async Task<UpdateAboutDto> UpdateByIdAsync(string id)
        {
            var about = await _aboutCollection.Find(a=>a.AboutId==id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateAboutDto>(about);
        }
    }
}
