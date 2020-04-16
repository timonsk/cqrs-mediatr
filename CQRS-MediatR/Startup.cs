using CQRS.MediatR.Handlers.Commands;
using CQRS.MediatR.Handlers.Queries;
using CQRS.MediatR.Interfaces.Commands;
using CQRS.MediatR.Interfaces.Queries;
using CQRS.MediatR.Interfaces.Storage;
using CQRS.MediatR.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CQRS.MediatR
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(IServiceCollection services)
        {
            RegisterDependencies(services);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterDependencies(IServiceCollection services)
        {
            // Register product handlers
            services.AddScoped<IProductCommandHandler, ProductCommandHandler>();
            services.AddScoped<IProductQueryHandler, ProductQueryHandler>();

            // Register category handlers
            services.AddScoped<ICategoryCommandHandler, CategoryCommandHandler>();
            services.AddScoped<ICategoryQueryHandler, CategoryQueryHandler>();

            services.AddSingleton<IInMemoryStorage, InMemoryStorage>();
        }
    }
}
