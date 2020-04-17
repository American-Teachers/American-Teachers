using AtApi.Framework;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace AtApi.Adapter
{
    public class LoggerAdapter<T> : IAdapter<T> where T : class
    {
        private readonly IAdapter<T> adapter;
        private readonly ILogger<T> logger;

        public LoggerAdapter(IAdapter<T> adapter, ILogger<T> logger)
        {
            this.adapter = adapter;
            this.logger = logger;
        }
        public T Create(T model)
        {
            logger.Log(LogLevel.Trace, $"Create({model.Serlialize()}");
            return adapter.Create(model);
        }

        public void Delete(int id)
        {
            logger.Log(LogLevel.Trace, $"Delete({id}");
            adapter.Delete(id);
        }

        public List<T> GetAll()
        {
            logger.Log(LogLevel.Trace, $"GetAll()");
            return adapter.GetAll();
        }

        public T GetOne(int id)
        {
            logger.Log(LogLevel.Trace, $"GetOne(id)");
            return adapter.GetOne(id);
        }

        public T Update(T model)
        {
            logger.Log(LogLevel.Trace, $"Update({model.Serlialize()}");
            return adapter.Update(model);
        }
    }
}
