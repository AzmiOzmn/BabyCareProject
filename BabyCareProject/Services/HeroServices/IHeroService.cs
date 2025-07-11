using BabyCareProject.Dtos.HeroDtos;

namespace BabyCareProject.Services.HeroServices
{
    public interface IHeroService
    {
        Task<List<ResultHeroDto>> GetAllAsync();

        Task<UpdateHeroDto> GetById(string id);

        Task UpdateHeroAsync(UpdateHeroDto updateHeroDto);

        Task CreateHeroAsync(CreateHeroDto createHeroDto);

        Task DeleteHeroAsync(string id);
    }
}
