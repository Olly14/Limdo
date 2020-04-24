using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Limdo.Web.App.ApiClients;
using Limdo.Web.App.DtoModels;
using Limdo.Web.App.HttpService;
using Limdo.Web.App.Models;
using Limdo.Web.App.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Limdo.Web.App.Controllers
{
    public class PcoLicencesDetailsController : Controller
    {

        private const string BaseUri = "PcoLicenceDetails";

        private const string AppUserBaseUri = "AppUsers";

        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;


        public PcoLicencesDetailsController(IApiClient apiClient, IMapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }


        [HttpGet]
        // GET: PcoLicencesDetails
        public async Task<ActionResult> Index()
        {
            var path = string.Format("{0}",  BaseUri);
            var pcoLicenceDetails = _mapper.Map<IEnumerable<PcoLicenceDetailViewModel>>(await _apiClient.ListAsync<PcoLicenceDetailDto>(path));
            //pcoLicenceDetails = await PopulateCountryUriKeyAsync(pcoLicenceDetails.ToList());
            return View(pcoLicenceDetails);
        }


        [HttpGet]
        // GET: PcoLicencesDetails/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var decodedId = GuidEncoder.Decode(id).ToString();

            var path = string.Format("{0}/{1}", BaseUri, decodedId);
            var pcoLicence = _mapper.Map<PcoLicenceDetailViewModel>(await _apiClient.GetAsync<PcoLicenceDetailDto>(path));
            return View(pcoLicence);
        }


        [HttpGet]
        // GET: PcoLicencesDetails/Create
        public ActionResult Create(string id)
        {
            //var decodedId = GuidEncoder.Decode(id).ToString();
            //var path = string.Format("{0}/{1}", AppUserBaseUri, decodedId);
            //var appUser = _mapper.Map<AppUserViewModel>(await _apiClient.GetAsync<AppUserDto>(path));
            var newPdl = new PcoLicenceDetailViewModel()
            {
                AppUserUriKey = id
            };

            return View(newPdl);
        }

        // POST: PcoLicencesDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PcoLicenceDetailViewModel model)
        {
            var decodedId = GuidEncoder.Decode(model.AppUserUriKey).ToString();
            var path = string.Format("{0}/{1}", AppUserBaseUri, decodedId);
            var appUser = _mapper.Map<AppUserViewModel>(await _apiClient.GetAsync<AppUserDto>(path));

            try
            {
                if (ModelState.IsValid)
                {
                    var createPath = string.Format("{0}{1}", HttpClientProvider.HttpClient.BaseAddress, BaseUri);
                    model.AppUser = appUser;
                    await _apiClient.PostAsync<PcoLicenceDetailDto>(createPath, _mapper.Map<PcoLicenceDetailDto>(model));
                    return RedirectToAction(nameof(Index));
                }
                // TODO: Add insert logic here

                return View();
            }
            catch(Exception ex)
            {
                var errMsg = ex.Message;
                return View();
            }
        }

        // GET: PcoLicencesDetails/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var decodedId = GuidEncoder.Decode(id).ToString();
            var path = string.Format("{0}/{1}", BaseUri, decodedId);
            var pdl = _mapper.Map<PcoLicenceDetailViewModel>(await _apiClient.GetAsync<PcoLicenceDetailDto>(path));
            pdl.UriKey = GuidEncoder.Encode(pdl.PcoId);
            return View(pdl);
        }

        // POST: PcoLicencesDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PcoLicenceDetailViewModel model)
        {
            var path = string.Format("{0}/{1}", BaseUri, model.UriKey);
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    await _apiClient.PutAsync<PcoLicenceDetailDto>(_mapper.Map<PcoLicenceDetailDto>(model));
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch(Exception ex)
            {
                var errMsg = ex.Message;
                return View();
            }
        }

        // GET: PcoLicencesDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PcoLicencesDetails/Delete/5
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

        public async Task<IEnumerable<PcoLicenceDetailViewModel>> PopulateCountryUriKeyAsync(List<PcoLicenceDetailViewModel> pcoLicenceDetails)
        {
            return await Task.Run(() =>

                pcoLicenceDetails.Select(pld => { pld.UriKey = GuidEncoder.Encode(pld.PcoId); return pld; })
            );
        }



    }
}