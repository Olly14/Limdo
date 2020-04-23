using System.Collections.Generic;
using System.Threading.Tasks;

namespace Limdo.Data.Infrastructure.Repositories.IDropDownLists
{
    public interface IDropDownListRepository <TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> FindAllAsync();
    }
}