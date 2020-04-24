using AutoMapper;
using Limdo.Web.App.ApiClients;
using Limdo.Web.App.DtoModels;
using Limdo.Web.App.HttpService;
using Limdo.Web.App.Models;
using Limdo.Web.App.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Limdo.Web.App.Controllers
{
    //[Authorize]
    public class CustomerRelationshipMgmsController : Controller
    {
        private const string BaseUri = "AppUsers";
        private const string UsersBaseUri = "Users";
        private const string BaseUriCountry = "DropDownLists/GetCountries";
        private const string BaseUriGender = "DropDownLists/GetGenders";


        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;


        public CustomerRelationshipMgmsController(IApiClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;

        }


        [HttpGet]
        // GET: CustomerRelationshipMgms
        public async Task<ActionResult> Index()
        {
            var users = await AppUsersAsync(BaseUri);
            users = PopulateUriKey(users);
            users = await PopulateCountryGenderIdsValuesOfUsersAsync(users.ToList());
            return View(users);
        }

        [HttpGet]
        // GET: CustomerRelationshipMgms/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var decodedId = GuidEncoder.Decode(id).ToString();

            var path = string.Format("{0}/{1}", BaseUri, decodedId);
            var user = await AppUserAsync(path);
            return View(user);
        }
        
        [HttpGet]
        // GET: CustomerRelationshipMgms/Create
        public async Task<ActionResult> Create(string id)
        {
           //var decodedId = GuidEncoder.Decode(id).ToString();
            var path = string.Format("{0}{1}/{2}", HttpClientProvider.HttpClient.BaseAddress, UsersBaseUri, id);
            var user = await _apiClient.GetAsync<UserDto>(path);
            
            var newUser = new AppUserViewModel();
            newUser.UriKey = GuidEncoder.Encode(user.SubjectId);
            return View(newUser);
        }

        // POST: CustomerRelationshipMgms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppUserViewModel model)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        // GET: CustomerRelationshipMgms/Edit/5
        public async Task<ActionResult> Edit(string id)
        {

            var decodedId = GuidEncoder.Decode(id).ToString();

            var path = string.Format("{0}/{1}", BaseUri, decodedId);
            var user = await AppUserAsync(path);
            return View(user);
        }

        // POST: CustomerRelationshipMgms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppUserViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerRelationshipMgms/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerRelationshipMgms/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        private IEnumerable<AppUserViewModel> PopulateUriKey(IEnumerable<AppUserViewModel> models)
        {
            models = models.Select(a =>
            {
                a.UriKey = GuidEncoder.Encode(a.AppUserId.ToString());
                return a;
            });
            return models;
        }


        private async Task<IEnumerable<GenderViewModel>> GetGendersAsync()
        {
            return await _apiClient.GetAsync<IEnumerable<GenderViewModel>>(BaseUriGender);
        }

        private async Task<IEnumerable<CountryViewModel>> GetCountriesAsync()
        {
            return await _apiClient.GetAsync<IEnumerable<CountryViewModel>>(BaseUriCountry);
        }


        private async Task<AppUserViewModel> AppUserAsync(string path)
        {
            return await _apiClient.GetAsync<AppUserViewModel>(path);
        }

        private async Task<IEnumerable<AppUserViewModel>> AppUsersAsync(string appUserBaseUri)
        {
            return await _apiClient.ListAsync<AppUserViewModel>(appUserBaseUri);
        }

        private async Task<IEnumerable<AppUserViewModel>> PopulateCountryGenderIdsValuesOfUsersAsync(List<AppUserViewModel> appUsers)
        {
            var countries = await GetCountriesAsync();
            var genders = await GetGendersAsync();
            return await Task.Run(() => appUsers.Select(au =>
             {

                 au = GetCountryIdValue(countries, au);
                 au = GetGenderIdValue(genders, au);
                 return au;
             }));

            //var countries = await GetCountriesAsync();
            //var genders = await GetGendersAsync();
            //appUser = await Task.Run(() => GetCountryIdValue(countries, appUser));
            //appUser = await Task.Run(() => GetGenderIdValue(genders, appUser));
            //return appUser;
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
    }
}