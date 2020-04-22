using AtApi.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace AtApi.Adapter
{
    public class AtContextAdapter<T> : IContextAdapter<T> where T : DbContext
    {
        private readonly T context;

        public AtContextAdapter(T context)
        {
            this.context = context;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return await context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}