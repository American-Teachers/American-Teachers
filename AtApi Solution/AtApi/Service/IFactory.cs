using System;
using System.Collections.Generic;

namespace AtApi.Service
{
    public interface IFactory<T> where T : class
    {

        T GetOne(int id);
        T Create(T teacherModel);

        T Update(T teacherModel);
        void Delete(int id);
        List<T> GetAll();
    }
}
