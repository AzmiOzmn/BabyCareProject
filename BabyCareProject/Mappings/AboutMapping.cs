using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.Dtos.AboutDtos;

namespace BabyCareProject.Mappings
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,ResultAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();
        }
    }
}
