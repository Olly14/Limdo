using Limdo.Web.App.DtoModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Limdo.Web.App.Models
{
    public class AppUserViewModel
    {
        public string AppUserId { get; set; }
        public string UriKey { get; set; }
        public string SubjectId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Password { get; set; }

        [Display(Name = "First Line Of Address")]
        public string FirstLineOfAddress { get; set; }
        [Display(Name = "Second Line Of Address")]
        public string SecondLineOfAddress { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        //public string Email { get; set; }
        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        public CountryDto Country { get; set; }
        [Display(Name = "Origin")]
        public string CountryId { get; set; }
        public string CountryIdValue { get; set; }
        [Display(Name = "Gender")]
        public string GenderId { get; set; }
        public string GenderIdValue { get; set; }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }
        [Display(Name = "Is Blocked")]
        public bool IsBlocked { get; set; }

        [Display(Name = "ModifierAppUserId")]
        public string ModifierAppUserId { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }


        //Navigation
        public virtual GenderDto Gender { get; set; }

        public virtual UserViewModel User { get; set; }

        public virtual PcoLicenceDetailViewModel PcoLicenceDetail { get; set; }


        public virtual ICollection<string> Roles { get; set; }
        public virtual ICollection<string> Claims { get; set; }

        public string DisplayName { get; set; }
    }
}
