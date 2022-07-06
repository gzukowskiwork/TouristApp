using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;
using TouristAppBackend.Application;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Infrastructure;
using TouristAppBackend.Infrastructure.Security;
using TouristAppBackend.Persistance;
using TouristAppBackend.Service;
using TouristAppBackend.ServicesExtensions;

namespace TouristAppBackend
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
            services.AddApplication();
            
            services.AddPersistance(Configuration);

            services.AddInfrastructure(Configuration);

            services.AddInfrastructureSecurity(Configuration);

            services.ConfigureCors();

            services.AddControllers();

            services.ConfigureSwagger();

            services.ConfigureIdentity();

            services.ConfigureJwt(Configuration);

            services.ConfigureAuthorization();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
                RequestPath = new PathString("/StaticFiles")
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TouristAppBackend v1");
                c.OAuthClientId("swagger");
                c.OAuth2RedirectUrl("https://localhost:5003/swagger/oauth2-redirect.html");
                c.OAuthUsePkce();
                });

            app.UseSerilogRequestLogging();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("My CORS policy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Sequrd by required authorization
                endpoints.MapControllers();
                //.RequireAuthorization("TouristApp");
            });
        }
    }
}
