using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.Dtos.NavbarDtos;

namespace BabyCareProject.Mappings
{
    public class NavbarMapping : Profile
    {
        public NavbarMapping()
        {
            CreateMap<Navbar,ResultNavbarDto>().ReverseMap();
            CreateMap<Navbar,UpdateNavbarDto>().ReverseMap();
            CreateMap<Navbar,CreateNavbarDto>().ReverseMap();
        }
    }
}
