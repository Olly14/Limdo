using System;
using Limdo.Data.Infrastructure.Repositories.IAppUsers;
using Limdo.Domain;


namespace Limdo.Data.Infrastructure.Persistences.AppUSerRepository
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(LimdoDbContext bankContext) : base(bankContext)
        {

        }

        //public AppUser GetUser(string username, string password)
        //{
        //    return BankDbContext.AppUsers.FirstOrDefault(aU =>
        //                aU.Username == username && aU.Password == password);
        //}

        public bool isAdmin(Guid adminIdAsGuid, string ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
