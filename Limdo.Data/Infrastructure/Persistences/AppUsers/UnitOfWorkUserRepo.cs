using Limdo.Data.Infrastructure.Repositories;
using Limdo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Limdo.Data.Infrastructure.Persistences.AppUsers
{
    public class UnitOfWorkUserRepo : UnitOfWorkUser<User>, IUnitOfWork<User>
    {
        public UnitOfWorkUserRepo(UserIdentityDbContext dbContext) : base(dbContext)
        {

        }
    }
}
