using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Limdo.Web.App.Controllers
{
    public class LimdoBaseController : Controller
    {

        public int MyProperty { get; set; }
        public IActionResult Index()
        {
            return View();
        }
    }
}