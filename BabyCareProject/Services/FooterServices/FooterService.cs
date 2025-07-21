using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.DataAccess.Settings;
using BabyCareProject.Dtos.FooterDtos;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCareProject.Services.FooterServices
{
    public class FooterService : IFooterService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Footer> _footerCollection;

        public FooterService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var mongoClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            _footerCollection = mongoDatabase.GetCollection<Footer>(databaseSettings.FooterCollectionName);
        }

        public Task CreateAsync(CreateFooterDto createFooterDto)
        {
            var values = _mapper.Map<Footer>(createFooterDto);
            return _footerCollection.InsertOneAsync(values);
        }

        public async Task DeleteAsync(string id)
        {
            await _footerCollection.DeleteOneAsync(x => x.FooterId == id);
        }

        public async Task<List<ResultFooterDto>> GetAllAsync()
        {
            var values = await _footerCollection.AsQueryable().ToListAsync();
           return _mapper.Map<List<ResultFooterDto>>(values);
        }

        public async Task<UpdateFooterDto> GetByIdAsync(string id)
        {
             var value = await _footerCollection.Find(x => x.FooterId == id).FirstOrDefaultAsync();
             return _mapper.Map<UpdateFooterDto>(value);
        }

        public async Task UpdateAsync(UpdateFooterDto updateFooterDto)
        {
            var footer = _mapper.Map<Footer>(updateFooterDto);
          await _footerCollection.FindOneAndReplaceAsync(x => x.FooterId == footer.FooterId, footer);
        }
    }
}
