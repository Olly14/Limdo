
using Limdo.Data.Infrastructure.Repositories;
using Limdo.Domain;

namespace Limdo.Data.Infrastructure.Persistences.AppUsers
{
    public class UnitOfWorkAppUserRepo : UnitOfWork<AppUser>, IUnitOfWork<AppUser>
    {
        public UnitOfWorkAppUserRepo(LimdoDbContext bankContext) : base(bankContext)
        {

        }
    }
}
