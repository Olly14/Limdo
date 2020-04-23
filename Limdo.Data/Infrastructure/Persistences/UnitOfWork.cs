using Limdo.Data.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Limdo.Data.Infrastructure.Persistences
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        protected readonly DbContext DbContext;

        private DbSet<TEntity> _dbSet;

        public LimdoDbContext BankDbContext => DbContext as LimdoDbContext;

        protected UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = DbContext.Set<TEntity>();
        }

        public async Task<TEntity> UpdateAsync(CancellationToken cancellationToken,TEntity entity)
        {
            var newAttachedAccount = _dbSet.Attach(entity);
            newAttachedAccount.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await this.CommitAsync(cancellationToken);
            return entity;
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
