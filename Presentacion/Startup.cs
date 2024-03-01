using Microsoft.EntityFrameworkCore;
using VehiculoPrueba.Core.Services;
using VehiculoPrueba.Core.Interfaces;
using Microsoft.OpenApi.Models;

namespace VehiculoPrueba
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
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VehiculoPrueba", Version = "v1" });
            });
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging(); // Esto mostrará los parámetros de las consultas SQL en el log
            });
            services.AddScoped<ILocalidadService, LocalidadService>();
            services.AddScoped<IVehiculoService, VehiculoService>();
            services.AddScoped<IRentaService, RentaService>();
            services.AddTransient<ITestService, TestService>();
            services.AddLogging(); 
            services.AddControllers();
            services.AddHttpContextAccessor();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VehiculoPrueba V1");
                c.RoutePrefix = "swagger/ui";
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
