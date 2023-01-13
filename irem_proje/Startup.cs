using irem_proje.application.Data;
using irem_proje.application.Data.Base;
using irem_proje.application.Services;
using irem_proje.application.Services.Base;
using irem_proje.application.Settings;
using irem_proje.application.Settings.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace irem_proje
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
            services.Configure<CaseDatabaseSettings>(Configuration.GetSection(nameof(CaseDatabaseSettings)));
            services.AddSingleton<ICaseDatabaseSettings>(sp => sp.GetRequiredService<IOptions<CaseDatabaseSettings>>().Value);

            services.AddScoped(typeof(CaseContext));
            services.AddScoped<ICaseContext, CaseContext>();
            services.AddScoped<IRepository, Repository>();

            services.Configure<RedisSettings>(Configuration.GetSection(nameof(RedisSettings)));
            services.AddSingleton<IRedisSettings>(sp => sp.GetRequiredService<IOptions<RedisSettings>>().Value);

            services.AddScoped(typeof(RedisContext));
            services.AddScoped<IRedisContext, RedisContext>();
            services.AddScoped<IBasketRepository, BasketRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "irem_proje", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "irem_proje v1"));
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
