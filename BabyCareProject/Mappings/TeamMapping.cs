using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.Dtos.TeamDtos;

namespace BabyCareProject.Mappings
{
    public class TeamMapping : Profile
    {
        public TeamMapping()
        {
            CreateMap<Team,ResultTeamDto>().ReverseMap();
            CreateMap<Team,UpdateTeamDto>().ReverseMap();
            CreateMap<Team,CreateTeamDto>().ReverseMap();
        }
    }
}
