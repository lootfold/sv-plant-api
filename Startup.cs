using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SVPlant.Core.Interfaces;
using SVPlant.Core.Services;
using SVPlant.Filters;
using SVPlant.Infrastructure.Data;
using SVPlant.Infrastructure.Repositories;

namespace SVPlant
{
    public class Startup
    {
        private const string _corsAllowAll = "AllowAll";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });

            services.AddDbContext<SVPlantDbContext>(opt =>
                opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(o =>
            {
                o.AddPolicy(name: _corsAllowAll, b => b.AllowAnyOrigin()
                                                        .AllowAnyHeader()
                                                        .AllowAnyMethod());
            });

            services.AddTransient<IPlantService, PlantService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPlantRepository, PlantRepository>();
            services.AddTransient<IWateringLogRepository, WateringLogRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope
                                .ServiceProvider
                                .GetRequiredService<SVPlantDbContext>();
                context.Database.Migrate();
            }
            app.UseCors(_corsAllowAll);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();
            app.UseDefaultFiles();
        }
    }
}
