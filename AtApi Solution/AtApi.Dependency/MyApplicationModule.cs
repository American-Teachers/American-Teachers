
using System;
using System.Configuration;
using System.Diagnostics;
using AtApi.Adapter;
using AtApi.Model;
using AtApi.Service;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            //Overrides          
            //services.AddScoped<ISharedServiceFactory, SharedServiceFactory>();
            //var appSettings = configuration.Get<AppSettings>();

            return services;
        }


    }
}
