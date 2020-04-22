using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtApi.Adapter
{
    public interface IAdapter<T> where T : class
    {
        Task<T> GetOneAsync(int id);
        T Create(T model);       
        Task DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
