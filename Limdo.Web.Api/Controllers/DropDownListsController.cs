using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Limdo.Data.Infrastructure.Repositories.IDropDownLists;
using Limdo.Domain;
using Limdo.Web.Api.DtoModels;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Limdo.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownListsController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IGenderRepository _genderRepository;

        //private readonly IUnitOfWork<User> _unitOfWorkUser;
        private CancellationToken _cancellationToken;

        private readonly IMapper _mapper;



        public DropDownListsController(IMapper mapper,
           ICountryRepository countryRepository,
           IGenderRepository genderRepository)
        {
            _countryRepository = countryRepository;
            _genderRepository = genderRepository;

            _mapper = mapper;
        }

        [HttpGet("GetGenders")]
        //[Route("api/DropDownLists/GetGenders")]
        public async Task<IEnumerable<GenderDto>> Get()
        {
            return _mapper.Map<IEnumerable<GenderDto>>(await _genderRepository.FindAllAsync());
        }


        [HttpGet("GetCountries")]
        //[Route("api/DropDownLists/GetCountries")]
        public async Task<IEnumerable<CountryDto>> GetCountries()
        {
            return _mapper.Map<IEnumerable<CountryDto>>(await _countryRepository.FindAllAsync());
        }
    }
}