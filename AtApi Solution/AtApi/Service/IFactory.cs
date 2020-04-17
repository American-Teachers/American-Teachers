using System;
using System.Collections.Generic;

namespace AtApi.Service
{
    public interface IFactory<T> where T : class
    {

        T GetOne(int id);
        T Create(T model);

        T Update(T model);
        void Delete(int id);
        List<T> GetAll();
    }
}
