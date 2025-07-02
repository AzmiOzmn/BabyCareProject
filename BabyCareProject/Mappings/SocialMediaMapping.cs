using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.Dtos.SocialMediaDtos;

namespace BabyCareProject.Mappings
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
        }
    }
}
