using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Radilovsoft.Rest.Data.Core.Contract;
using Radilovsoft.Rest.Data.Core.Contract.Provider;
using Radilovsoft.Rest.Data.Ef.Context;
using Radilovsoft.Rest.Data.Ef.Contract;
using Radilovsoft.Rest.Data.Ef.Provider;
using Radilovsoft.Rest.Infrastructure.Contract.Helper;
using Radilovsoft.Rest.Infrastructure.Helpers;
using Sample.Web.Admin.Services;
using Sample.Auth.Contracts;
using Sample.Auth.Services;
using Sample.Db.Context;
using Sample.Db.Manager;
using Sample.Db.Provider;
using Sample.Db.Store;
using Sample.Infrastructure.Contracts;

namespace Sample.Web.Admin
{
    public class Startup
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public Startup(ILoggerFactory loggerFactory,
            IConfiguration configuration,
            IWebHostEnvironment env)
        {
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _env = env ?? throw new ArgumentNullException(nameof(env));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddControllers();

            var defaultApiVersion = new ApiVersion(1, 0);
            services.AddApiVersioning(o =>
                {
                    o.ReportApiVersions = true;
                    o.AssumeDefaultVersionWhenUnspecified = true;
                    o.DefaultApiVersion = defaultApiVersion;
                })
                .AddVersionedApiExplorer(o =>
                {
                    o.GroupNameFormat = "'v'VVV";
                    o.SubstituteApiVersionInUrl = true;
                })
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = $"Tester Admin API {defaultApiVersion}",
                        Version = defaultApiVersion.ToString()
                    });
                });


            services.AddEntityFrameworkNpgsql()
                .AddDbContext<TesterDbContext>((sp, ob) =>
                {
                    ob.UseNpgsql(_configuration.GetConnectionString("Postgres"));
                    if (_loggerFactory != null)
                    {
                        ob.UseLoggerFactory(_loggerFactory);
                    }
                })
                .AddScoped<ResetDbContext>(x => x.GetService<TesterDbContext>())
                .AddScoped<IDataProvider, EfDataProvider>()
                .AddScoped<IRoDataProvider>(x => x.GetService<IDataProvider>())
                .AddScoped<IModelStore, TesterDbModelStore>()
                .AddScoped<IAsyncHelpers, EfAsyncHelpers>()
                .AddScoped<IDataExceptionManager, PostgresDbExceptionManager>()
                .AddScoped<IIndexProvider, PostgresIndexProvider>();

            services.AddScoped<IRoleRoService, RoleRoService>();
            services.AddScoped<IFilterHelper, FilterHelper>();
            services.AddScoped<IExpressionHelper, ExpressionHelper>();
            services.AddScoped<IOrderHelper, OrderHelper>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPasswordProvider, PasswordProvider>();
            services.AddScoped<ITokenProvider, EmptyTokenProvider>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IHostApplicationLifetime lifetime, IServiceProvider serviceProvider,
            IApiVersionDescriptionProvider provider)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            if (env == null) throw new ArgumentNullException(nameof(env));
            if (lifetime == null) throw new ArgumentNullException(nameof(lifetime));
            if (serviceProvider == null) throw new ArgumentNullException(nameof(serviceProvider));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                foreach (var versionDescription in provider.ApiVersionDescriptions)
                {
                    o.SwaggerEndpoint($"/swagger/{(object) versionDescription.GroupName}/swagger.json",
                        versionDescription.GroupName.ToUpperInvariant());
                }

                o.EnableDeepLinking();
            });

            app.UseRouting();
            // app.UseAuthentication();
            // app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}