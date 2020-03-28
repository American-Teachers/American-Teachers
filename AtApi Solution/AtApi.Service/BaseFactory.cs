using AtApi.Adapter;
using System.Collections.Generic;

namespace AtApi.Service
{
    public abstract class BaseFactory<T,A> : IFactory<T> where T: class where A: IBaseAdapter<T>
    {
        public BaseFactory(A adapter)
        {
            _teacherAdapter = adapter;
        }

        private A _teacherAdapter;

        public virtual T Create(T teacherModel)
        {
            return _teacherAdapter.Create(teacherModel);
        }

        public virtual void Delete(int id)
        {
            _teacherAdapter.Delete(id);
        }

        public virtual List<T> GetAll()
        {
            return _teacherAdapter.GetAll();
        }

        public virtual T GetOne(int id)
        {
            return _teacherAdapter.GetOne(id);
        }

        public virtual T Update(T teacherModel)
        {
            return _teacherAdapter.Update(teacherModel);
        }
    }
}
