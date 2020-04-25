using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Limdo.Web.App.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync();
            await HttpContext.SignOutAsync("oidc");
        }
    }
}