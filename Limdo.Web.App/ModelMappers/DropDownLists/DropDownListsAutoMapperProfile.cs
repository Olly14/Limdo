




using AutoMapper;
using Limdo.Web.App.DtoModels;
using Limdo.Web.App.Models;

namespace Limdo.Web.App.ModelMappers.DropDownLists
{
    public class DropDownListsAutoMapperProfile : Profile
    {
        public DropDownListsAutoMapperProfile()
        {
            CreateMap<CountryDto, CountryViewModel>().ReverseMap();
            CreateMap<GenderDto, GenderViewModel>().ReverseMap();
        }
    }
}
