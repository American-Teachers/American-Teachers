using AtApi.Adapter;
using System;
using System.Collections.Generic;

namespace AtApi.Service
{
    public abstract class BaseFactory<T, A> : IFactory<T> where T : class
                                                          where A : IAdapter<T>
    {
        public BaseFactory(A adapter)
        {
            _adapter = adapter;
        }

        private A _adapter;

        public virtual T Create(T model)
        {
            return _adapter.Create(model);
        }

        public virtual void Delete(int id)
        {
            _adapter.Delete(id);
        }

        public virtual List<T> GetAll()
        {
            return _adapter.GetAll();
        }

        public virtual T GetOne(int id)
        {
            return _adapter.GetOne(id);
        }

        public virtual T Update(T model)
        {
            return _adapter.Update(model);
        }
    }
}
