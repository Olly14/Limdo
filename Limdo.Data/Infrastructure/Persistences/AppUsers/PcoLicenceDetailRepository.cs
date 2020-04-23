using Limdo.Data.Infrastructure.Repositories.IAppUsers;
using Limdo.Domain;




namespace Limdo.Data.Infrastructure.Persistences.AppUsers
{
    public class PcoLicenceDetailRepository : Repository<PcoLicenceDetail>, IPcoLicenceDetailRepository
    {
        public PcoLicenceDetailRepository(LimdoDbContext bankContext) : base(bankContext)
        {

        }
    }
}
