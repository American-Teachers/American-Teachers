using AtApi.Model;
using System;
using System.Collections.Generic;

namespace AtApi.Adapter
{
    public class BaseAdapter<T> : IBaseAdapter<T> where T : class, new()
    {
        public virtual T Create(T model)
        {
            return new T();
        }

        public virtual void Delete(int id)
        {

        }

        public virtual List<T> GetAll()
        {
            return new List<T>() { new T(), new T() };
        }

        public virtual T GetOne(int id)
        {
            return new T();
        }

        public virtual T Update(T model)
        {
            return model;
        }
    }
}
