using Limdo.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Limdo.Data.Infrastructure.Repositories.IAppUsers
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindUserByUserNameAsync(string username);
    }
}
