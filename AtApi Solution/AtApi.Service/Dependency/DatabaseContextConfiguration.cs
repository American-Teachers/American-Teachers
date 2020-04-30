
using AtApi.Model.At;
using AtApi.Model.Settings;
using AtApi.Service.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AtApi.Dependency
{
    public static class DatabaseContextConfiguration
    {
        public static IServiceCollection ConfigureDataContext(this IServiceCollection services, AppSettings appSettings, ILoggerFactory loggerFactory)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(appSettings.ConnectionStrings.AmericanTeachers);
                options.UseLoggerFactory(loggerFactory);  
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            services.AddDbContext<AtDbContext>(options =>
            {
                options.UseLoggerFactory(loggerFactory); 
                options.UseSqlServer(appSettings.ConnectionStrings.AmericanTeachers);
            });
            
            return services;
        }
    }
}
