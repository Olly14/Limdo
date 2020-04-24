using Limdo.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Limdo.Web.Api.DtoModels
{
    public class AppUserDto
    {
        public string AppUserId { get; set; }

        public string SubjectId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string Password { get; set; }

        public string FirstLineOfAddress { get; set; }
        public string SecondLineOfAddress { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        //public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }
        public Country Country { get; set; }
        public string CountryId { get; set; }
        public string GenderId { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsBlocked { get; set; }

        public string ModifierAppUserId { get; set; }

        public DateTime ModifiedDate { get; set; }


        //Navigation
        public virtual Gender Gender { get; set; }

        public virtual PcoLicenceDetailDto PcoLicenceDetail { get; set; }

        public virtual User User { get; set; }

        [NotMapped]
        public virtual ICollection<string> Roles { get; set; }
        [NotMapped]
        public virtual ICollection<string> Claims { get; set; }
    }
}
