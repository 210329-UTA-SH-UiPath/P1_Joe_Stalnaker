using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<PizzaBoxDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PizzaBoxDb"))
            );
            var foo = services.AddScoped<IRepository<AComponent>, ComponentRepository>();
            services.AddScoped<IRepository<Domain.Models.Customer>, CustomerRepository>();
            services.AddScoped<IRepository<Domain.Models.Menu>, MenuRepository>();
            services.AddScoped<IRepository<Domain.Models.Order>, OrderRepository>();
            services.AddScoped<IRepository<APizza>, PizzaRepository>();
            services.AddScoped<IRepository<AStore>, StoreRepository>();
            //services.AddScoped<ISuperHeroRepository, SuperHeroRepository>();
            //services.AddScoped<ISuperPowerRepository, SuperPowerRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaBox.Service", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaBox.Service v1"));
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
