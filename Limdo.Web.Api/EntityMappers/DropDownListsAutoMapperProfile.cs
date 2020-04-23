using AutoMapper;
using Limdo.Domain;
using Limdo.Web.Api.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Limdo.Web.Api.EntityMappers
{
    public class DropDownListsAutoMapperProfile : Profile
    {
        public DropDownListsAutoMapperProfile()
        {
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
        }
    }
}
