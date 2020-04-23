using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Limdo.Domain;

namespace Limdo.Data.Infrastructure.Repositories.IAppUsers
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        //AppUser GetUser(string username, string password);

        Task<AppUser> FindByAppUserIdAsync(string id);
        bool isAdmin(Guid adminIdAsGuid, string ownerId);
        //object GetUser(string username, string password);
    }
}
