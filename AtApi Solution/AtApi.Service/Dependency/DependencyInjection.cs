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
            //services.ScanTransient<IAdapter<Student>>(); //Adapter
            services.ScanTransient<IFactory<Enrollment>>(); //Service
            services.ScanTransient<Class>();
            
            
            //services.ScanTransient<IEmailSender>();
            //Overrides          
            //var appSettings = configuration.Get<AppSettings>();



            services.Decorate<IAdapter<Class>, LoggerAdapterDecorator<Class>>();
            services.Decorate<IAdapter<Enrollment>, LoggerAdapterDecorator<Enrollment>>();
            services.Decorate<IAdapter<Parent>, LoggerAdapterDecorator<Parent>>();
            services.Decorate<IAdapter<School>, LoggerAdapterDecorator<School>>();
            services.Decorate<IAdapter<Student>, LoggerAdapterDecorator<Student>>();
            services.Decorate<IAdapter<Teacher>, LoggerAdapterDecorator<Teacher>>();


            services.Decorate<IFactory<Class>, LoggerFactoryDecorator<Class>>();
            services.Decorate<IFactory<Enrollment>, LoggerFactoryDecorator<Enrollment>>();
            services.Decorate<IFactory<Parent>, LoggerFactoryDecorator<Parent>>();
            services.Decorate<IFactory<School>, LoggerFactoryDecorator<School>>();
            services.Decorate<IFactory<Student>, LoggerFactoryDecorator<Student>>();
            services.Decorate<IFactory<Teacher>, LoggerFactoryDecorator<Teacher>>();


            return services;
        }


    }
}
