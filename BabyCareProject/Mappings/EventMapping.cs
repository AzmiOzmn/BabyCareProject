using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.Dtos.EventDtos;

namespace BabyCareProject.Mappings
{
    public class EventMapping : Profile
    {
        public EventMapping()
        {
            CreateMap<Event ,ResultEventDto>().ReverseMap();
            CreateMap<Event ,UpdateEventDto>().ReverseMap();
            CreateMap<Event, CreateEventDto>().ReverseMap();
        }
    }
}
