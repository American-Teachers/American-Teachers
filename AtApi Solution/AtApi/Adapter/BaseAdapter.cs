using AtApi.Model;
using AtApi.Model.At;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtApi.Adapter
{
    public abstract class AtBaseAdapter<T> : IAdapter<T> where T : class
    {
        protected readonly AtDbContext atDbContext;

        public AtBaseAdapter(AtDbContext atDbContext)
        {
            this.atDbContext = atDbContext;
        }
        public virtual T Create(T model)
        {
            var e = atDbContext.Add<T>(model);
            return e.Entity;
        }
 
        public virtual async Task DeleteAsync(int id)
        {
            var model = await GetOneAsync(id).ConfigureAwait(false);
            atDbContext.Set<T>().Remove(model);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await atDbContext.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public virtual Task<T> GetOneAsync(int id)
        {
            throw new NotImplementedException();
        }
 
    }
}
