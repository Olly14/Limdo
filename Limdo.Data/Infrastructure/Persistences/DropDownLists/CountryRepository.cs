using Microsoft.EntityFrameworkCore;
using Limdo.Domain;
using Limdo.Data.Infrastructure.Repositories.IDropDownLists;

namespace Limdo.Data.Infrastructure.Persistences.DropDownLists
{
    public class CountryRepository : DropDownListRepository<Country>, ICountryRepository
    {
        public CountryRepository(LimdoDbContext dbContext):base(dbContext)
        {
                
        }
    }
}
