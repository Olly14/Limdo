
using System.Collections.Generic;



namespace Limdo.Web.App.DtoModels
{
    public class GenderDto
    {
        public string GenderId { get; set; }
        public string Type { get; set; }

        //Navigation property
        public virtual IEnumerable<AppUserDto> AppUsers { get; set; }
    }
}
