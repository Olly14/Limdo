using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Limdo.Web.Api.DtoModels
{
    public class PcoLicenceDetailDto
    {
        public string PcoId { get; set; }

        public string ExprireDate { get; set; }

        public string IssueDate { get; set; }

        public string AppUserId { get; set; }

        public AppUserDto AppUser { get; set; }
    }
}
