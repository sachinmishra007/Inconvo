using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Footboll.Team.WebApi.Configuration.Swagger
{
    public class SwaggerImplementation
    {
        public static void EnableSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);

                c.SwaggerDoc("v1", CommonUtils.CommonUtils.GetV1ApiSwaggerInfo());
            });

        }

        public static void ConfigureSwagger(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API --> V1.0 Documentation");
                c.DocumentTitle = "Football Team -API Documentation";
                c.DocExpansion(DocExpansion.None);
            });
        }
    }
}
