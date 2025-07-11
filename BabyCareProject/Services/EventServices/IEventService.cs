using BabyCareProject.Dtos.EventDtos;

namespace BabyCareProject.Services.EventServices
{
    public interface IEventService
    {
        Task<List<ResultEventDto>>GetAllAsync();

        Task<UpdateEventDto> GetById(string id);

        Task CreateAsync(CreateEventDto createEventDto);

        Task DeleteAsync(string id);

        Task UpdateAsync(UpdateEventDto updateEventDto);

    }
}
