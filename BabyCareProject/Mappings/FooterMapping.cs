using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.Dtos.FooterDtos;

namespace BabyCareProject.Mappings
{
    public class FooterMapping : Profile
    {
        public FooterMapping()
        {
            CreateMap<Footer,ResultFooterDto>().ReverseMap();
            CreateMap<Footer,UpdateFooterDto>().ReverseMap();
            CreateMap<Footer,CreateFooterDto>().ReverseMap();
        }
    }
}
