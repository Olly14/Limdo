using Limdo.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Limdo.Data.Infrastructure.Repositories.IAppUsers
{
    public interface IPcoLicenceDetailRepository : IRepository<PcoLicenceDetail>
    {
        Task<PcoLicenceDetail> FindPldByAppUserId(string id);
    }


}
