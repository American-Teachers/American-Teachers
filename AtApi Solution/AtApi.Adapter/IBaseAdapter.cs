using AtApi.Model;
using System.Collections.Generic;

namespace AtApi.Adapter
{
    public interface IBaseAdapter<T> where T: class
    {
        T GetOne(int id);
        T Create(T teacherModel);
        T Update(T teacherModel);
        void Delete(int id);
        List<T> GetAll();
    }
}
