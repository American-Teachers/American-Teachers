using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
namespace AtApi.Dependency
{
    public static class DependencyFactory
    {
        public static IServiceCollection ScanTransient<ITransientService>(this IServiceCollection services)
        {
            return services.Scan(scan => scan.FromAssemblyOf<ITransientService>().AddClasses().AsImplementedInterfaces().WithTransientLifetime());
        }
        public static IServiceCollection ScanTransient<ITransientService>(this IServiceCollection services, Action<IImplementationTypeFilter> action)
        {
            return services.Scan(scan => scan.FromAssemblyOf<ITransientService>().AddClasses(action).AsImplementedInterfaces().WithTransientLifetime());
        }
        public static IServiceCollection ScanScoped<IScopedService>(this IServiceCollection services)
        {
            return services.Scan(scan => scan.FromAssemblyOf<IScopedService>().AddClasses().AsImplementedInterfaces().WithScopedLifetime());
        }
        public static IServiceCollection ScanGeneric<T>(this IServiceCollection services, Type genericType)
        {
            return services.Scan(scan => scan.FromAssemblyOf<T>().AddClasses(classes => classes.AssignableTo(genericType)).AsImplementedInterfaces());
        }
    }
}