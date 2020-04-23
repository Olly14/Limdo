using System.Collections.Generic;
using System.Threading.Tasks;
using Limdo.Data.Infrastructure.Repositories.IDropDownLists;
using Microsoft.EntityFrameworkCore;

namespace Limdo.Data.Infrastructure.Persistences
{
    public abstract class DropDownListRepository<TEntity> : IDropDownListRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext DbContext;

        private  DbSet<TEntity> _dbSet;

        public LimdoDbContext BankDbContext => DbContext as LimdoDbContext;

        public DropDownListRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = DbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
           return await Task.Run(() => _dbSet) ;
        }
    }
}
