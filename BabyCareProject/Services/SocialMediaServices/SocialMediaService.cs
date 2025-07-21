using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.DataAccess.Settings;
using BabyCareProject.Dtos.SocialMediaDtos;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCareProject.Services.SocialMediaServices
{

    public class SocialMediaService : ISocialMediaService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<SocialMedia> _socialMediaCollection;

        public SocialMediaService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var mongoClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            _socialMediaCollection = mongoDatabase.GetCollection<SocialMedia>(databaseSettings.SocialMediaCollectionName);
        }
        public Task CreateAsync(CreateSocialMediaDto createSocialMediaDto)
        {
        var values = _mapper.Map<SocialMedia>(createSocialMediaDto);
            return _socialMediaCollection.InsertOneAsync(values);
        }

        public async Task DeleteAsync(string id)
        {
          await _socialMediaCollection.DeleteOneAsync(x => x.SocialMediaId == id);
        }

        public async Task<List<ResultSocialMediaDto>> GetAllAsync()
        {
           var values = await _socialMediaCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultSocialMediaDto>>(values);
        }

        public async Task<UpdateSocialMediaDto> GetByIdAsync(string id)
        {
           var value = await _socialMediaCollection.Find(x => x.SocialMediaId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateSocialMediaDto>(value);
        }

        public Task UpdateAsync(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var socialMedia = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            return _socialMediaCollection.FindOneAndReplaceAsync(x => x.SocialMediaId == socialMedia.SocialMediaId, socialMedia);

        }
    }
}
