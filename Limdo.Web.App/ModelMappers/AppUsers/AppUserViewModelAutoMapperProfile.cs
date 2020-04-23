using AutoMapper;
using Limdo.Web.App.DtoModels;
using Limdo.Web.App.Models;

namespace Limdo.Web.App.ModelMappers.AppUsers
{
    public class AppUserViewModelAutoMapperProfile : Profile
    {
        public AppUserViewModelAutoMapperProfile()
        {
            CreateMap<AppUserDto, AppUserViewModel>().ReverseMap();
            CreateMap<UserDto, RegistratioViewModel>().ReverseMap();
        }

    }
}
