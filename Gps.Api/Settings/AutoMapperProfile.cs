using AutoMapper;
using Gps.Api.ViewModels;
using Gps.Core.Domain;

namespace Gps.Api.Settings
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