using AtApi.Framework;
using AtApi.Adapter;
using AtApi.Model;
using AtApi.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CDBLSA.Dependency;


namespace AtApi.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(c => configuration);
            services.ScanTransient<IBaseAdapter<EnrollModel>>();
            services.ScanTransient<IFactory<EnrollModel>>();
            services.ScanTransient<ClassModel>();
            services.ScanTransient<IEmailSender>();
            //Overrides          
            //services.AddScoped<ISharedServiceFactory, SharedServiceFactory>();
            //var appSettings = configuration.Get<AppSettings>();

            return services;
        }


    }
}
