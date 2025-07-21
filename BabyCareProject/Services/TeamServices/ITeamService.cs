using BabyCareProject.Dtos.TeamDtos;

namespace BabyCareProject.Services.TeamServices
{
    public interface ITeamService
    {
        Task<List<ResultTeamDto>> GetAllAsync();
        Task<UpdateTeamDto> GetByIdAsync(string id);
        Task CreateAsync(CreateTeamDto createTeamDto);
        Task DeleteAsync(string id);
        Task UpdateAsync(UpdateTeamDto updateTeamDto);

    }
}
