using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Limdo.Web.App.DtoModels
{
    public class PcoLicenceDetailDto
    {
        public string PcoLicenceNumber { get; set; }
        public string ExprireDate { get; set; }

        public string IssueDate { get; set; }

        public AppUserDto AppUser { get; set; }

        public string AppUserId { get; set; }
    }
}
