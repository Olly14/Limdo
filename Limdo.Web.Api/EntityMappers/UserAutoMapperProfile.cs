using AutoMapper;
using Limdo.Domain;
using Limdo.Web.Api.DtoModels;


namespace Limdo.Web.Api.EntityMappers
{
    public class UserAutoMapperProfile : Profile
    {
        public UserAutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<PcoLicenceDetail, PcoLicenceDetailDto>().ReverseMap();
        }
    }
}
