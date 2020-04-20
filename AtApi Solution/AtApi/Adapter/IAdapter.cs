using System.Collections.Generic;

namespace AtApi.Adapter
{
    public interface IAdapter<T> where T : class
    {
        T GetOne(int id);
        T Create(T model);
        T Update(T model);
        void Delete(int id);
        List<T> GetAll();
    }
}
