using BabyCareProject.Dtos.SocialMediaDtos;

namespace BabyCareProject.Services.SocialMediaServices
{
    public interface ISocialMediaService
    {
        Task<List<ResultSocialMediaDto>> GetAllAsync();
        Task<UpdateSocialMediaDto> GetByIdAsync(string id);
        Task CreateAsync(CreateSocialMediaDto createSocialMediaDto);
        Task DeleteAsync(string id);
        Task UpdateAsync(UpdateSocialMediaDto updateSocialMediaDto);
    }
}
