using BabyCareProject.Dtos.NavbarDtos;

namespace BabyCareProject.Services.NavbarServices
{
    public interface INavbarService
    {
        Task<List<ResultNavbarDto>> GetAllAsync();
        Task<UpdateNavbarDto> GetByIdAsync(string id);
        Task CreateAsync(CreateNavbarDto createNavbarDto);
        Task UpdateAsync(UpdateNavbarDto updateNavbarDto);
        Task DeleteAsync(string id);
    }
}
