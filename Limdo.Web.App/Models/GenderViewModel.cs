using Limdo.Web.App.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Limdo.Web.App.Models
{
    public class GenderViewModel
    {
        public string GenderId { get; set; }
        public string Type { get; set; }
        public string UriKey { get; set; }

        //Navigation property
        public virtual IEnumerable<AppUserDto> AppUsers { get; set; }
    }
}
