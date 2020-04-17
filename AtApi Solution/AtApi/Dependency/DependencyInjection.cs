using AtApi.Adapter;
using AtApi.Framework;
using AtApi.Model;
using AtApi.Model.At;
using AtApi.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AtApi.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(c => configuration);
            services.ScanTransient<IBaseAdapter<Student>>();
            services.ScanTransient<IFactory<Enrollment>>();
            services.ScanTransient<Class>();
            services.ScanTransient<IEmailSender>();
            //Overrides          
            //services.AddScoped<ISharedServiceFactory, SharedServiceFactory>();
            //var appSettings = configuration.Get<AppSettings>();

            return services;
        }


    }
}
