using Footboll.Team.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Footboll.Team.WebApi.Configuration.ApiVersion
{
    public class ApiVersionImplementation
    {
        public static void EnablingVersioning(IServiceCollection services)
        {
            services.AddApiVersioning(c =>
            {
                c.ReportApiVersions = true;
                c.AssumeDefaultVersionWhenUnspecified = true;
                c.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                c.Conventions.Controller<FootballTeamController>().HasApiVersion(new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0));

            });
        }
    }
}
