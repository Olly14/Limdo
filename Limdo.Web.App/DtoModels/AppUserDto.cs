


using System;
using System.Collections.Generic;

namespace Limdo.Web.App.DtoModels
{
    public class AppUserDto
    {
        public string AppUserId { get; set; }

        public string SubjectId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string Password { get; set; }

        public string FirstLineOfAddress { get; set; }
        public string SecondLineOfAddress { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        //public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }
        public CountryDto Country { get; set; }
        public string CountryId { get; set; }
        public string GenderId { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsBlocked { get; set; }

        public string ModifierAppUserId { get; set; }

        public DateTime ModifiedDate { get; set; }


        //Navigation
        public virtual GenderDto Gender { get; set; }

        public virtual UserDto User { get; set; }

        public virtual PcoLicenceDetailDto PcoLicenceDetail { get; set; }


        public virtual ICollection<string> Roles { get; set; }

        public virtual ICollection<string> Claims { get; set; }
    }
}
