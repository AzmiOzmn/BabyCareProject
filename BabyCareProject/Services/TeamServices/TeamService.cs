using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.DataAccess.Settings;
using BabyCareProject.Dtos.TeamDtos;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCareProject.Services.TeamServices
{
    public class TeamService : ITeamService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Team> _teamCollection;

        public TeamService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            _teamCollection = mongoDatabase.GetCollection<Team>(databaseSettings.TeamCollectionName);
            _mapper = mapper;
        }
        public Task CreateAsync(CreateTeamDto createTeamDto)
        {
          var team = _mapper.Map<Team>(createTeamDto);
            return _teamCollection.InsertOneAsync(team);
        }

        public async Task DeleteAsync(string id)
        {
            await _teamCollection.DeleteOneAsync(x => x.TeamId == id);

        }

        public async Task<List<ResultTeamDto>> GetAllAsync()
        {
           var values = await _teamCollection.AsQueryable().ToListAsync();
          return _mapper.Map<List<ResultTeamDto>>(values);
        }

        public async Task<UpdateTeamDto> GetByIdAsync(string id)
        {
           var value = await _teamCollection.Find(x => x.TeamId == id).FirstOrDefaultAsync();
         return  _mapper.Map<UpdateTeamDto>(value);
        }

        public Task UpdateAsync(UpdateTeamDto updateTeamDto)
        {
          var team = _mapper.Map<Team>(updateTeamDto);
            return _teamCollection.FindOneAndReplaceAsync(x => x.TeamId == team.TeamId, team);
        }
    }
}
