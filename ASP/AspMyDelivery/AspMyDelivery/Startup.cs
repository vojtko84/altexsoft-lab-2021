using System;
using AspMyDelivery.API.Filters;
using AspMyDelivery.BLL.Interfaces;
using AspMyDelivery.BLL.Services;
using DeliveryEF.Data;
using DeliveryEF.Data.Repositories;
using DeliveryEF.Data.UoW;
using DeliveryEF.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyDelivery.Controllers;
using MyDelivery.Data;
using MyDelivery.Interfaces;
using MyDelivery.Loggers;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

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
            var configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();

            services.AddControllers(o =>
            {
                o.Filters.Add(typeof(MyExceptionFilter));
            });
            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspMyDelivery", Version = "v1" });
            });
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<DbContext, DataContext>();
            services.AddTransient<IRepository<Product>, EFRepository<Product>>();
            services.AddTransient<IRepository<Category>, EFRepository<Category>>();
            services.AddTransient<IRepository<Provider>, EFRepository<Provider>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IMyLogger, MyLogger>();
            services.AddTransient<ICache, Cache>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProviderService, ProviderService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<MyActionFilter>();
            services.AddResponseCaching();
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

            app.UseResponseCaching();

            app.UseRouting();

            app.UseAuthorization();
            app.Use(next => context =>
            {
                context.Request.EnableBuffering();
                return next(context);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "mvc",
                pattern: "mvc/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}