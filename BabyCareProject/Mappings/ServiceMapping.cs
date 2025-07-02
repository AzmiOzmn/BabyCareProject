using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.Dtos.ServiceDtos;

namespace BabyCareProject.Mappings
{
    public class ServiceMapping : Profile
    {
        public ServiceMapping()
        {
            CreateMap<Service,ResultServiceDto>().ReverseMap();
            CreateMap<Service,UpdateServiceDto>().ReverseMap();
            CreateMap<Service,CreateServiceDto>().ReverseMap();
        }
    }
}
