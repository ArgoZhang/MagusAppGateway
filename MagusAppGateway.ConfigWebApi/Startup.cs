using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.OpenApi.Models;
using MagusAppGateway.Contexts;
using MagusAppGateway.Services.Services;
using MagusAppGateway.Services.IServices;
using MagusAppGateway.Services.Automapper;

namespace MagusAppGateway.ConfigWebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("DBConnection");
            services.AddControllers();
            services.AddDbContext<UserDatabaseContext>(options => {
                options.UseNpgsql(connectionString, 
                    sql => sql.MigrationsAssembly(typeof(Startup).Assembly.FullName));
            },ServiceLifetime.Singleton);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIdentityResourceService, IdentityResourceService>();
            services.AddScoped<IApiScopeService, ApiScopeService>();
            services.AddScoped<IClientService, ClientService>();

            services.AddAutoMapper(typeof(AutomapperConfig));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "��������", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "��������");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}