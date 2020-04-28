using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtApi.Service
{
    public interface IFactory<T> where T : class
    {

        Task<T> GetOneAsync(int id);
        Task<T> CreateAsync(T model, bool saveChanges = true);

        Task<T> UpdateAsync(T model, bool saveChanges = true);
        Task DeleteAsync(int id, bool saveChanges = true);
        Task<List<T>> GetAllAsync();
    }
}
