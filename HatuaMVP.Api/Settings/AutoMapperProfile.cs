using AutoMapper;
using HatuaMVP.Core.Domain;

namespace HatuaMVP.Api.Settings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}