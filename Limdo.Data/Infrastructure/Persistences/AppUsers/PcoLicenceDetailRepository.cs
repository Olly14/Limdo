using Limdo.Data.Infrastructure.Repositories.IAppUsers;
using Limdo.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Limdo.Data.Infrastructure.Persistences.AppUsers
{
    public class PcoLicenceDetailRepository : Repository<PcoLicenceDetail>, IPcoLicenceDetailRepository
    {
        public PcoLicenceDetailRepository(LimdoDbContext bankContext) : base(bankContext)
        {

        }

        public async Task<PcoLicenceDetail> FindPldByAppUserId(string id)
        {
            return await Task.Run(() => LimdoDbContext.PcoDetails.FirstOrDefault(pdl => pdl.AppUserId == id));
        }
    }
}
