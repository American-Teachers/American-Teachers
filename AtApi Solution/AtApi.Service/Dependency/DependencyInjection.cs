using AtApi.Model.At;
using AtApi.Model.Settings;
using AtApi.Service.Adapter;
using AtApi.Service.Factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AtApi.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(c => configuration);
            services.ScanTransient<AppSettings>();  //Model                      
            services.ScanTransient<IFactory<Enrollment>>(); //Service         
            services.Decorate(typeof(IAdapter<>), typeof( LoggerAdapterDecorator<>));
            services.Decorate(typeof(IFactory<>), typeof(LoggerFactoryDecorator<>));
            services.Decorate<IPersonManager, LoggerPersonManager>();


            return services;
        }


    }
}
