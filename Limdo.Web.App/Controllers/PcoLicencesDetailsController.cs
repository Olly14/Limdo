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
            var path = string.Format("{0}{1}", HttpClientProvider.HttpClient.BaseAddress, BaseUri);
            var pcoLicenceDetails = _mapper.Map<IEnumerable<PcoLicenceDetailViewModel>>(await _apiClient.ListAsync<PcoLicenceDetailDto>(path));
            pcoLicenceDetails = await PopulateCountryUriKeyAsync(pcoLicenceDetails.ToList());
            return View(pcoLicenceDetails);
        }

        // GET: PcoLicencesDetails/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var decodedId = GuidEncoder.Decode(id).ToString();

            var path = string.Format("{0}/{1}", BaseUri, decodedId);
            var pcoLicence = _mapper.Map<PcoLicenceDetailViewModel>(await _apiClient.GetAsync<PcoLicenceDetailDto>(path));
            return View(pcoLicence);
        }

        // GET: PcoLicencesDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PcoLicencesDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PcoLicencesDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PcoLicencesDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
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