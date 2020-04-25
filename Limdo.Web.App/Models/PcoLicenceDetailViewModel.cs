﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Limdo.Web.App.Models
{
    public class PcoLicenceDetailViewModel
    {
        public string PcoLicenceNumber { get; set; }

        [Display(Name = "Expire Date")]
        public string ExprireDate { get; set; }

        [Display(Name = "Issue Date")]
        public string IssueDate { get; set; }

        public AppUserViewModel AppUser { get; set; }

        public string AppUserId { get; set; }

        public string UriKey { get; set; }

        public string AppUserUriKey { get; set; }


    }
}
