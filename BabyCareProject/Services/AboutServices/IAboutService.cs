using BabyCareProject.Dtos.AboutDtos;

namespace BabyCareProject.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task<UpdateAboutDto> UpdateByIdAsync(string id);

        Task CreateAboutAsync (CreateAboutDto createAboutDto);
        Task UpdateAboutAsync (UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync (string id);

        
        
    }
}
