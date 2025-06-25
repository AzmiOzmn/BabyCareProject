using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.DataAccess.Settings;
using BabyCareProject.Dtos.NavbarDtos;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCareProject.Services.NavbarServices
{
    public class NavbarService : INavbarService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Navbar> _navbarCollection;

        public NavbarService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var mongoClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            _navbarCollection = mongoDatabase.GetCollection<Navbar>(databaseSettings.NavbarCollectionName);
        }

        public async Task CreateAsync(CreateNavbarDto createNavbarDto)
        {
            var values = _mapper.Map<Navbar>(createNavbarDto);
            await _navbarCollection.InsertOneAsync(values);
        }

        public async Task DeleteAsync(string id)
        {
            await _navbarCollection.DeleteOneAsync(x => x.NavbarId == id);
        }

        public async Task<List<ResultNavbarDto>> GetAllAsync()
        {
            var values = await _navbarCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultNavbarDto>>(values);
        }

        public async Task<UpdateNavbarDto> GetByIdAsync(string id)
        {
            var values = await _navbarCollection.Find(a => a.NavbarId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateNavbarDto>(values);
        }

        public async Task UpdateAsync(UpdateNavbarDto updateNavbarDto)
        {
            var navbar = _mapper.Map<Navbar>(updateNavbarDto);
            await _navbarCollection.FindOneAndReplaceAsync(x => x.NavbarId == navbar.NavbarId, navbar);
        }
    }
}
