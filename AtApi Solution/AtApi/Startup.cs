using AtApi.Dependency;
using AtApi.Middlewares;
using AtApi.Model.Settings;
using AtApi.Swagger;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AtApi.Service.Authorization;

namespace AtApi
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        private IServiceProvider _serviceProvider;
        //public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
            // In ASP.NET Core 3.0 `env` will be an IWebHostingEnvironment, not IHostingEnvironment.
            var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddUserSecrets(appAssembly, false)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencyInjection(Configuration);

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            services.AddHttpContextAccessor();
            services.AddOptions();
            services.AddLogging();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddHttpClient();

            services.AddVersionedApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                opt.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                    .WithOrigins(appSettings.AllowedOrigins)
                    .AllowCredentials());
            });

#pragma warning disable ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
            _serviceProvider = services.BuildServiceProvider();
#pragma warning restore ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
             
            var loggerFactory = _serviceProvider.GetService<ILoggerFactory>();
            services.ConfigureDataContext(appSettings, loggerFactory);
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = appSettings.Authentication.Google.ClientId;
                googleOptions.ClientSecret = appSettings.Authentication.Google.ClientSecret;
            });

            services.AddControllers().ConfigureApiBehaviorOptions(a => a.SuppressMapClientErrors = true);
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(opt =>
            {
                opt.ExampleFilters();

                var xmlPath = GetXmlDataAnnotationFilePath();
                if (!string.IsNullOrEmpty(xmlPath))
                {
                    opt.IncludeXmlComments(xmlPath);
                }

                opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Authorization header. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                opt.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            var key = Encoding.ASCII.GetBytes(appSettings.JwtSecretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie(cfg => { cfg.SlidingExpiration = true; })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
            services.AddAuthorizationCore(options => {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireClaim(Claims.GoogleToken)
                .RequireAuthenticatedUser()
                .Build();
            });
            services.AddSwaggerExamplesFromAssemblyOf<Program>();


            var logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .ReadFrom.Configuration(Configuration);

            Log.Logger = logger.CreateLogger();
            Log.Information("web api service is started.");
        }

        private string GetXmlDataAnnotationFilePath()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (!File.Exists(xmlPath))
            {
                return null;
            }

            return xmlPath;
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            // AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("AllowSpecificOrigin");

            app.UseHttpContextMiddleware();

            
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
          
            //app.UseWebServices();

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
                foreach (var description in provider.ApiVersionDescriptions.OrderByDescending(o => o.GroupName))
                {
                    c.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            });

        }
    }
}
