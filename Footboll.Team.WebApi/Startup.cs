using System;
using System.Text;
using System.Threading.Tasks;
using Footboll.Team.WebApi.Configuration;
using Footboll.Team.WebApi.Configuration.ApiVersion;
using Footboll.Team.WebApi.Configuration.AppDependencies;
using Footboll.Team.WebApi.Configuration.Swagger;
using Footboll.Team.WebApi.Constants;
using Footboll.Team.WebApi.Controllers;
using Footboll.Team.WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Footboll.Team.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Implementation for the Dependencies
            DependenciesImplementation.EnableDependencies(services);          
            //Implement the Swagger UI
            SwaggerImplementation.EnableSwagger(services);
            //Implemenation for the API Versioning
            ApiVersionImplementation.EnablingVersioning(services);
            //Implemenation for the JWT Token
            JWTImplementation.EnablingJWTAuthentication(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            //Enables the JWT Authentication
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            //Implemented the Middleware for Exception Handling
            app.UseExceptionHandlingMiddleware();
            //Configure Swgger UI 
            SwaggerImplementation.ConfigureSwagger(app, env);
        }       
        
    }
}
