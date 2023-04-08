using Catalog.Application.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;
using MediatR;
using Catalog.Infrastructure.Data;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Repositories;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Catalog.API
{
    public class Statrup
    {
        public IConfiguration Configuration { get; }
        public Statrup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning();
            services.AddHealthChecks().AddMongoDb(Configuration["DatabaseSettings:ConnectionString"], "Catalog Mongo Db Health Check", HealthStatus.Degraded);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Catalog.API", Version = "v1" }); });

            //DI 
            services.AddAutoMapper(typeof(Statrup));
            services.AddMediatR(typeof(CreateProductHandler).GetTypeInfo().Assembly);
            services.AddScoped<ICatalogContext,CatalogContext>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IBrandRepository,ProductRepository>();
            services.AddScoped<ITypesRepository,ProductRepository>();
        }
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","Catalog.API v1"));
            }
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

            });
        }
    }
}
