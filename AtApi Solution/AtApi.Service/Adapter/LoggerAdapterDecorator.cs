using AtApi.Framework;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtApi.Service.Adapter
{
    public class LoggerAdapterDecorator<T> : IAdapter<T> where T : class
    {
        private readonly IAdapter<T> adapter;
        private readonly ILogger<IAdapter<T>> logger;

        public LoggerAdapterDecorator(IAdapter<T> adapter, ILogger<IAdapter<T>> logger)
        {
            this.adapter = adapter;
            this.logger = logger;
        }
        public T Create(T model)
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.Log(LogLevel.Trace, () => $"Adapter<{typeof(T)}>.Create(${nameof(model)}");
            }
            else
            {
                logger.Log(LogLevel.Trace, () => $"Adapter<{typeof(T)}>.Create({model.Serlialize()}");
            }
            return adapter.Create(model);
        }

        public async Task DeleteAsync(int id)
        {
            logger.Log(LogLevel.Debug, () => $"Adapter<{typeof(T)}>.Delete({id}");
            await adapter.DeleteAsync(id).ConfigureAwait(false);
        }

        public async Task<List<T>> GetAllAsync()
        {
            logger.Log(LogLevel.Debug, () => $"Adapter<{typeof(T)}>.GetAll()");
            return await adapter.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<T> GetOneAsync(int id)
        {
            logger.Log(LogLevel.Debug, () => $"Adapter<{typeof(T)}>.GetOne(id)");
            return await adapter.GetOneAsync(id);
        }

        //public T Update(T model)
        //{
        //    if (logger.IsEnabled(LogLevel.Debug))
        //    {
        //        logger.Log(LogLevel.Debug, () => $"Update({nameof(model)}");
        //    }
        //    else
        //    {
        //        logger.Log(LogLevel.Trace, () => $"Update({model.Serlialize()}");
        //    }
        //    return adapter.Update(model);
        //}
    }
}
