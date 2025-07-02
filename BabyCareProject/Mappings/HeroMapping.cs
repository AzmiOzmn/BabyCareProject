using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.Dtos.HeroDtos;

namespace BabyCareProject.Mappings
{
    public class HeroMapping : Profile
    {
        public HeroMapping()
        {
            CreateMap<Hero,CreateHeroDto>().ReverseMap();
            CreateMap<Hero,UpdateHeroDto>().ReverseMap();
            CreateMap<Hero,ResultHeroDto>().ReverseMap();
        }
    }
}
