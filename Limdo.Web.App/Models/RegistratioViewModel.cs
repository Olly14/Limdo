using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Limdo.Web.App.Models
{
    public class RegistratioViewModel
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public bool IsActive { get; set; }

        public bool IsBlocked { get; set; }


    }
}
