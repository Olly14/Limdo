using Limdo.Data.Infrastructure.Repositories.IAppUsers;
using Limdo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limdo.Data.Infrastructure.Persistences.AppUsers
{
    public class UserIdentityRepository : UserRepository<User>, IUserRepository
    {
        public UserIdentityRepository(UserIdentityDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> FindUserByUserNameAsync(string username)
        {
            return await Task.Run(() => UserIdentityDbContext.Users.Where(u => u.Username == username).FirstOrDefault());
        }
    }
}
