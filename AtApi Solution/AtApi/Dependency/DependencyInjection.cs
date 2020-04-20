using AtApi.Adapter;
using AtApi.Framework;
using AtApi.Model;
using AtApi.Model.At;
using AtApi.Model.Settings;
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
            services.ScanTransient<IAdapter<Student>>();
            services.ScanTransient<IFactory<Enrollment>>();
            services.ScanTransient<Class>();
            services.ScanTransient<IEmailSender>();
            //Overrides          
            var appSettings = configuration.Get<AppSettings>();
            services.Decorate<IAdapter<Class>, LoggerAdapter<Class>>();
            services.Decorate<IAdapter<Student>, LoggerAdapter<Student>>();
            services.Decorate<IAdapter<Teacher>, LoggerAdapter<Teacher>>();
            return services;
        }


    }
}
