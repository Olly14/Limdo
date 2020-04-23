using System.Collections.Generic;
using System.Threading.Tasks;

namespace Limdo.Web.App.ApiClients
{
    public interface IApiClient
    {
        Task<ICollection<T>> ListAsync<T>(string uri);
        Task<ICollection<T>> ListAsync<T>();
        
        Task<T> GetAsync<T>(string uri);
        Task<T> GetAsync<T>();
        
        Task PutAsync<T>(string uri, T updatedItem);
        Task PutAsync<T>(T updatedItem);
        
        Task<T> PostAsync<T>(string uri, T newItem);
        Task<T> PostAsync<T>(T newItem);

        Task<bool> DeleteAsync(string uri);

        //Task<Result> ResultantListAsync<T>(string uri);
        //Task<Result<T>> ResultantGetAsync<T>(string uri);
        //Task<Result> ResultantPutAsync<T>(string uri, T updatedItem);
        //Task<Result<T>> ResultantPostAsync<T>(string uri, T newItem);
        //Task<TResult> PostWithResultAsync<TData, TResult>(string uri, TData newItem);
        //Task<Result<TResult>> ResultantPostWithResultAsync<TData, TResult>(string uri, TData newItem);
    }
}
