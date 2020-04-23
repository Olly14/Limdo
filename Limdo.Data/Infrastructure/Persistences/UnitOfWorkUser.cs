using Limdo.Data.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Limdo.Data.Infrastructure.Persistences
{
    public class UnitOfWorkUser<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        protected readonly DbContext DbContext;

        protected static TEntity _tEntity = default;

        private DbSet<TEntity> _dbSet;

        public UserIdentityDbContext BankDbContext => DbContext as UserIdentityDbContext;

        protected UnitOfWorkUser(DbContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = DbContext.Set<TEntity>();

        }

        public async Task<TEntity> UpdateAsync(CancellationToken cancellationToken, TEntity entity)
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
