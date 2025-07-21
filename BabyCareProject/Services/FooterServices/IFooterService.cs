using BabyCareProject.Dtos.FooterDtos;

namespace BabyCareProject.Services.FooterServices
{
    public interface IFooterService
    {
        Task<List<ResultFooterDto>> GetAllAsync();

        Task<UpdateFooterDto> GetByIdAsync(string id);

        Task CreateAsync(CreateFooterDto createFooterDto);

        Task DeleteAsync(string id);

        Task UpdateAsync(UpdateFooterDto updateFooterDto);
    }
}
