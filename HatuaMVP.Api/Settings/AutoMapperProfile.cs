using AutoMapper;
using HatuaMVP.Api.ViewModels;
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