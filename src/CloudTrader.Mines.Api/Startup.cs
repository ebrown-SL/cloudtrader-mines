using AutoMapper;
using CloudTrader.Mines.Api.Exceptions;
using CloudTrader.Mines.Data;
using CloudTrader.Mines.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CloudTrader.Mines.Api
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
            services.AddScoped<IMineService, MineService>();
            services.AddScoped<IMineRepository, MineRepository>();
            services.AddAutoMapper(typeof(MineProfile));
            services.AddMvc(options =>
            {
                options.Filters.Add(new GlobalExceptionFilter());
            });
            services.AddDbContext<MineContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
