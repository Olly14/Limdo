using Microsoft.EntityFrameworkCore;
using Limdo.Domain;
using Limdo.Data.Infrastructure.Repositories.IDropDownLists;

namespace Limdo.Data.Infrastructure.Persistences.DropDownLists
{
    public class GenderRepository : DropDownListRepository<Gender>, IGenderRepository
    {
        public GenderRepository(LimdoDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
