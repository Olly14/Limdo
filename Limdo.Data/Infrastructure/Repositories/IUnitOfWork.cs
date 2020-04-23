using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Limdo.Data.Infrastructure.Repositories
{
    public interface IUnitOfWork<TEntity> where TEntity : class
    {
        Task<TEntity> UpdateAsync(CancellationToken cancellationToken, TEntity entity);

        Task CommitAsync(CancellationToken cancellationToken);

        //Task<TEntity> GetNewlyCreatedEntityAsync(CancellationToken cancellationToken, TEntity entity);
    }
}
