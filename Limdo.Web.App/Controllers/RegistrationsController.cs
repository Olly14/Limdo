using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Limdo.Data.Security.Helpers;
using Limdo.Web.App.ApiClients;
using Limdo.Web.App.DtoModels;
using Limdo.Web.App.HttpService;
using Limdo.Web.App.Models;
using Limdo.Web.App.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Limdo.Web.App.Controllers
{
    public class RegistrationsController : Controller
    {
        private const string Registration_BaseUri = "Users";
        private const string Registration_EmailUri = "Users/GetUserBymail";
        private const string User_ByUserIdUri = "Users/GetByUserId";
        private const string Registration_UserUri = "Users/GetUser";

        private const string Genders_Uri = "DropDownLists/GetGenders";
        private const string DDL_Uri = "DropDownLists";
        private const string Countries_Uri = "DropDownLists/GetCountries";

        private const string Base_AppUserUri = "AppUsers";
        private const string AppUsers_Post = "AppUsers/PostAppUser";
        private const string Base_GetAppUserUri = "AppUsers/GetByAppUserId";
        private const string AppUsers_Put = "AppUsers/PutAppUser";

        private readonly IMapper _mapper;
        private readonly IApiClient _apiClient;

        public RegistrationsController(IMapper mapper, IApiClient apiClient)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            var newUser = new RegistratioViewModel();
            return View(newUser);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Registration(RegistratioViewModel model)
        {
            model.Username = model.Email;
            var path = string.Format("{0}{1}", HttpClientProvider.HttpClient.BaseAddress, Registration_BaseUri);

            if (ModelState.IsValid)
            {
                model.Password = PasswordBaseKeyDerivationFunction.HashPassword(model.Password);
                model.IsActive = true;
                var result = _mapper.Map<UserDto>(await _apiClient.PostAsync(path, model));

                return RedirectToAction("Edit", new { id = model.Email });

            }


            return View();
        }

        // GET: CustomerRelationshipMgms/Details/5
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Details(string id)
        {

            var path = string.Format("{0}/{1}", User_ByUserIdUri, GuidEncoder.Decode(id).ToString()) ;
            var user = await _apiClient.GetAsync<UserDto>(path);
            var appUserPath = string.Format("{0}/{1}", Base_GetAppUserUri, GuidEncoder.Decode(id).ToString());
            var appUser = _mapper.Map<AppUserViewModel>(await _apiClient.GetAsync<AppUserDto>(appUserPath));
            appUser = await PopulateCountryGenderIdsValuesAsync(appUser);


            return View(appUser);
        }

        [HttpGet]
        public async Task<ActionResult> Create(string id)
        {
            var path = string.Format("{0}/{1}", Registration_EmailUri, id);
            var user = await _apiClient.GetAsync<UserDto>(path);

            var newUser = new AppUserViewModel();
            newUser.UriKey = GuidEncoder.Encode(user.SubjectId);
            return View(newUser);
        }


        [Authorize]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Create(AppUserViewModel model)
        {
            var path = string.Format("{0}/{1}", Registration_BaseUri, model);
            var user = await _apiClient.PostAsync<UserDto>(path, _mapper.Map<UserDto>(model));

            var newUser = new AppUserViewModel();
            newUser.UriKey = GuidEncoder.Encode(user.SubjectId);
            return View(newUser);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Edit(string id)
        {
            await PopulateViewBagsAsync();
            
            var path = string.Format("{0}/{1}", Registration_BaseUri, id);
            var user = await _apiClient.GetAsync<UserDto>(path);

            var newUser = new AppUserViewModel();
            newUser.UriKey = GuidEncoder.Encode(user.SubjectId);
            newUser.DisplayName = id;
            return View(newUser);
        }

        // POST: CustomerRelationshipMgms/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AppUserViewModel model)
        {

            var userPath = string.Format("{0}/{1}", User_ByUserIdUri, GuidEncoder.Decode(model.UriKey));
            var user = _mapper.Map<UserViewModel>(await _apiClient.GetAsync<UserDto>(userPath));



            try
            {
                var redirectUrlParam = model.UriKey;
                var path = string.Format("{0}", AppUsers_Put);
                //model.SubjectId = GuidEncoder.Decode(model.UriKey).ToString();
                model.CreatedDate = DateTime.UtcNow;
                model.ModifiedDate = DateTime.UtcNow;
                model.GenderId = GuidEncoder.Decode(model.GenderId).ToString();
                model.CountryId = GuidEncoder.Decode(model.CountryId).ToString();

                if (ModelState.IsValid)
                {
                    model.User = user;
                    await _apiClient.PutAsync(path, _mapper.Map<AppUserDto>(model));
                    return RedirectToAction("Details", new {id = redirectUrlParam});
                }
                // TODO: Add update logic here

                return View();
            }
            catch(Exception ex)
            {
                var msgError = ex.Message;
                return View();
            }
        }


        private async Task<AppUserViewModel> PopulateCountryGenderIdsValuesAsync(AppUserViewModel appUser)
        {
            var countries = await GetCountriesAsync();
            var genders = await GetGendersAsync();
            appUser = await Task.Run(() => GetCountryIdValue(countries, appUser));
            appUser = await Task.Run(() => GetGenderIdValue(genders, appUser));
            return appUser;
        }

        private AppUserViewModel GetCountryIdValue(IEnumerable<CountryViewModel> genders, AppUserViewModel appUser)
        {
            appUser.CountryIdValue = genders.FirstOrDefault(g => string.Compare(g.CountryId, appUser.CountryId, true) == 0).CountryName;
            return appUser;
        }

        private AppUserViewModel GetGenderIdValue(IEnumerable<GenderViewModel> genders, AppUserViewModel appUser)
        {
            appUser.GenderIdValue = genders.FirstOrDefault(g => string.Compare(g.GenderId, appUser.GenderId, true) == 0).Type;
            return appUser;
        }



        private async Task<IEnumerable<CountryViewModel>> GetCountriesAsync()
        {
            var path = string.Format("{0}", Countries_Uri);
            return _mapper.Map<IEnumerable<CountryViewModel>>(await _apiClient.ListAsync<CountryDto>(path));
        }

        private async Task<CountryViewModel> GetCountryAsync(string countryId)
        {
            //var path = string.Format("{0}", Countries_Uri);
            var path = string.Format("{0}", Countries_Uri);
            return _mapper.Map<CountryViewModel>(await _apiClient.ListAsync<CountryDto>(path));
        }

        private async Task<IEnumerable<GenderViewModel>> GetGendersAsync()
        {
            //var path = string.Format("{0}", Genders_Uri);
            var path = string.Format("{0}", Genders_Uri);
            return _mapper.Map<IEnumerable<GenderViewModel>>(await _apiClient.ListAsync<GenderDto>(path));
        }

        private async Task<GenderViewModel> GetGenderAsync(string genderId)
        {
            var path = string.Format("{0}/{1}", Countries_Uri, genderId);
            return _mapper.Map<GenderViewModel>(await _apiClient.GetAsync<GenderDto>(path));
        }

        public async Task<IEnumerable<GenderViewModel>> PopulateGenderUriKeyAsync(List<GenderViewModel> genders)
        {
            return await Task.Run(() => 

                genders.Select(g => { g.UriKey = GuidEncoder.Encode(g.GenderId); return g; })
            );
        }

        public async Task<IEnumerable<CountryViewModel>> PopulateCountryUriKeyAsync(List<CountryViewModel> countries)
        {
            return await Task.Run(() =>

                countries.Select(g => { g.UriKey = GuidEncoder.Encode(g.CountryId); return g; })
            );
        }

        public async Task PopulateViewBagsAsync()
        {
            var genders = await GetGendersAsync();
            var countries = await GetCountriesAsync();
            genders = await PopulateGenderUriKeyAsync(genders.ToList());
            countries = await PopulateCountryUriKeyAsync(countries.ToList());
            ViewBag.Genders = genders;
            ViewBag.Countries = countries;
        }
    }
}