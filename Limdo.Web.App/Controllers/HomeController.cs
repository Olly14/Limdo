using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Limdo.Web.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Threading.Tasks;

namespace Limdo.Web.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHttpContextAccessor _httpContectAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContectAccessor)
        {
            _logger = logger;
            _httpContectAccessor = httpContectAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var currentContext = _httpContectAccessor.HttpContext;

            var IdentityToken = await currentContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);


            return View();
        }

        public async Task<IActionResult> About()
        {
            var currentContext = _httpContectAccessor.HttpContext;

            var IdentityToken = await currentContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            ViewBag.Message = "London Independent Minicab Organisation";
            ViewBag.Title = "About Limdo";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
