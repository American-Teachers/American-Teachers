using AtApi.Adapter;
using AtApi.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtApi.Service
{
    public abstract class BaseFactory<T, TDbContext> : IFactory<T> where T : class
                                                          where TDbContext : DbContext
    {
        protected readonly IAdapter<T> adapter;
        protected readonly IContextAdapter<TDbContext> contextAdapter;
        protected BaseFactory(IAdapter<T> adapter, IContextAdapter<TDbContext> contextAdapter)
        {
            this.adapter = adapter;
            this.contextAdapter = contextAdapter;
        }


        public virtual async Task<T> CreateAsync(T model, bool saveChanges = true)
        {
            var e = adapter.Create(model);
            if (saveChanges)
            {
                await contextAdapter.SaveChangesAsync().ConfigureAwait(false);
            }
            return e;
        }

        public virtual async Task DeleteAsync(int id, bool saveChanges = true)
        {
            await adapter.DeleteAsync(id);
            if (saveChanges)
            {
                await contextAdapter.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await adapter.GetAllAsync().ConfigureAwait(false);
        }

        public virtual async Task<T> GetOneAsync(int id)
        {
            return await adapter.GetOneAsync(id).ConfigureAwait(false);
        }

        public virtual async Task<T> UpdateAsync(T model, bool saveChanges = true)
        {
            if (saveChanges)
            {
                await contextAdapter.SaveChangesAsync().ConfigureAwait(false);
            }
            return model;
        }


        //{
        //    return adapter.Update(model);
        //    if (saveChanges)
        //    {
        //        await contextAdapter.SaveChangesAsync().ConfigureAwait(false);
        //    }
        //}
    }
}
