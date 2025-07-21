using BabyCareProject.Dtos.ServiceDtos;

namespace BabyCareProject.Services.ServiceServices
{
    public interface IServiceService
    {
        Task<List<ResultServiceDto>> GetAllAsync();
        Task<UpdateServiceDto> GetByIdAsync(string id);
        Task CreateAsync(CreateServiceDto createServiceDto);
        Task DeleteAsync(string id);
        Task UpdateAsync(UpdateServiceDto updateServiceDto);
    }
}
