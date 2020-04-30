using AtApi.Framework;
using AtApi.Model;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AtApi.Service.Factory
{
    class LoggerPersonManager : IPersonManager
    {
        private readonly IPersonManager personManager;
        private readonly ILogger<LoggerPersonManager> logger;

        public LoggerPersonManager(IPersonManager personManager, ILogger<LoggerPersonManager> logger)
        {
            this.personManager = personManager;
            this.logger = logger;
        }
        public async Task<PersonResponse> CreateAsync(PersonRequest personRequest)
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.Log(LogLevel.Debug, () => $"CreateAsync({personRequest})");
            }
            else
            {
                logger.Log(LogLevel.Trace, () => $" CreateAsync({personRequest.Serlialize()}");
            }
            return await personManager.CreateAsync(personRequest);
        }
    }
}
