using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EndPointsEF.DataContext;
using EndPointsEF.Services;
using EndPointsEF.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EndPointsEF
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
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Muebleria_Connection"))
                .EnableSensitiveDataLogging(true).UseLazyLoadingProxies();
            });

            services.AddDbContext<abcDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Contac_Connection"))
                .EnableSensitiveDataLogging(true).UseLazyLoadingProxies();
            });

            // Automapper
            services.AddSingleton(provider =>
            {
                return new MapperConfiguration(config =>
                {
                    // apunta al AutoMapperProfile dode se especifica el ampeo
                    // debe de heredar Profile de AutoMapper
                    config.AddProfile<AutoMapperProfile>();
                    config.ConstructServicesUsing(type =>
                        ActivatorUtilities.GetServiceOrCreateInstance(provider, type));
                }).CreateMapper();
            });

            // Servcios con sus implementaciones
            services.AddTransient<IMuebleService, MuebleService>();
            // Srevicio Cliente
            services.AddTransient<IClienteService, ClienteService>();
            // Servicio Factura
            services.AddTransient<IFacturaService, FacturaService>();
            // Localidad Service
            services.AddTransient<ILocalidadService, LocalidadService>();
            // Files Service
            services.AddTransient<IFilesService, FilesService>();

            // Configuracion de mis Settings
            services.Configure<MySettings>(Configuration.GetSection("MySettings"));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
    }
}
