using DeliveryEF.Data;
using DeliveryEF.Data.Repositories;
using DeliveryEF.Data.UoW;
using DeliveryEF.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyDelivery.Controllers;
using MyDelivery.Data;
using MyDelivery.Interfaces;
using MyDelivery.Loggers;

namespace AspMyDelivery
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspMyDelivery", Version = "v1" });
            });
            services.AddTransient<DbContext, DataContext>();
            services.AddTransient<IRepository<Product>, EFRepository<Product>>();
            services.AddTransient<IRepository<Category>, EFRepository<Category>>();
            services.AddTransient<IRepository<Provider>, EFRepository<Provider>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ILogger, Logger>();
            services.AddTransient<ICache, Cache>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspMyDelivery v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}