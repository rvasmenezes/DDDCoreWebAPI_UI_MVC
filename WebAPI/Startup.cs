using Application.Apps;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.Generic;
using Domain.Interfaces.Usuarios;
using Infra.Repository;
using Infra.Repository.Generics;
using Infra.Repository.Usuarios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebAPI
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

            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGeneric<>));
            services.AddSingleton<ICliente, RepositoryCliente>();
            services.AddSingleton<IAppCliente, ApplicationCliente>();
            services.AddSingleton<IEndereco, RepositoryEndereco>();
            services.AddSingleton<IAppEndereco, ApplicationEndereco>();

            services.AddSingleton<IUsuario, RepositoryUsuarios>();
            services.AddSingleton<IAppUsuario, ApplicationUsuario>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Test API", Version = "1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option =>
            {
                option.RouteTemplate = swaggerOptions.JsonRoute;
            });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UiEndPoint, swaggerOptions.Description);
            });

            //app.UseMvc();
            //app.UseSwagger();

            //app.UseSwaggerUI(option => {
            //    option.SwaggerEndpoint("/swagger/v1/swagger.json", "Core API");
            //});

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
