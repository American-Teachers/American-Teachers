using AtApi.Dependency;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AtApi.Data;
using Microsoft.EntityFrameworkCore;
using AtApi.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System;
using AtApi.Model.Settings;
using Microsoft.Extensions.Logging;

namespace AtApi
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        private IServiceProvider _serviceProvider;
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
            // In ASP.NET Core 3.0 `env` will be an IWebHostingEnvironment, not IHostingEnvironment.
            var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddUserSecrets(appAssembly, false)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencyInjection(Configuration);
            services.Configure<AppSettings>(Configuration);
            services.AddHttpContextAccessor();
            services.AddOptions();
            services.AddLogging();
#pragma warning disable ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
            _serviceProvider = services.BuildServiceProvider();
#pragma warning restore ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
            var appSettings = _serviceProvider.GetService<IOptions<AppSettings>>().Value;

            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseMySql(appSettings.ConnectionStrings.AmericanTeachers));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.ConfigureDataContext(appSettings, MyLoggerFactory);
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = appSettings.Authentication.Google.ClientId;
                googleOptions.ClientSecret = appSettings.Authentication.Google.ClientSecret;
            });


            services.AddControllers().ConfigureApiBehaviorOptions(a => a.SuppressMapClientErrors = true);
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "American Teachers", Version = "v1" });
            });
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        /* public void ConfigureContainer(ContainerBuilder builder)
         {
             // Register your own things directly with Autofac, like:
             builder.RegisterModule(new MyApplicationModule());
         }
         */
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(e =>
            {
                e.MapControllers();
                e.MapDefaultControllerRoute();
                e.MapRazorPages();
                e.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "American Teachers API V1");
            });
        }
    }
}
