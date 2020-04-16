using AtApi.Adapter.At;
using AtApi.Model.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AtApi.Dependency
{
    public static class DatabaseContextConfiguration
    {
        public static IServiceCollection ConfigureDataContext(this IServiceCollection services, AppSettings appSettings, ILoggerFactory loggerFactory)
        {
            services.AddDbContext<AtDbContext1>(options =>
            {
                options.UseLoggerFactory(loggerFactory); // Warning: Do not create a new ILoggerFactory instance each time
                options.UseMySql(appSettings.ConnectionStrings.AmericanTeachers);
            });

            new AtDbContext1(appSettings.ConnectionStrings.AmericanTeachers).Database.Migrate();
            return services;
        }
    }
}
