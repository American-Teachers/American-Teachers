using AtApi.Framework;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtApi.Service
{
    public class LoggerFactoryDecorator<T> : IFactory<T> where T : class
    {
        private readonly IFactory<T> factory;
        private readonly ILogger<T> logger;
        public LoggerFactoryDecorator(ILogger<T> logger, IFactory<T> factory)
        {
            this.logger = logger;
            this.factory = factory;
        }
        public async Task<T> CreateAsync(T model, bool saveChanges = true)
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.Log(LogLevel.Trace, () => $"Create(${nameof(model)},{saveChanges}");
            }
            else
            {
                logger.Log(LogLevel.Trace, () => $"Create({model.Serlialize()},{saveChanges}");
            }
            return await factory.CreateAsync(model, saveChanges).ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id, bool saveChanges = true)
        {
            logger.Log(LogLevel.Debug, () => $"Delete({id}, {saveChanges}");
            await factory.DeleteAsync(id, saveChanges);
        }

        public async Task<List<T>> GetAllAsync()
        {
            logger.Log(LogLevel.Debug, () => $"GetAll()");
            return await factory.GetAllAsync();
        }

        public async Task<T> GetOneAsync(int id)
        {
            logger.Log(LogLevel.Debug, () => $"GetOneAsync({id})");
            return await factory.GetOneAsync(id);
        }

        public async Task<T> UpdateAsync(T model, bool saveChanges = true)
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.Log(LogLevel.Debug, () => $"Update({nameof(model)}, {saveChanges}");
            }
            else
            {
                logger.Log(LogLevel.Trace, () => $"Update({model.Serlialize()}, {saveChanges}");
            }
            return await factory.UpdateAsync(model, saveChanges);

        }
    }
}
