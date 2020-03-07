using Football.Team.BussinessLogic.Interfaces;
using Football.Team.BussinessLogic.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Footboll.Team.WebApi.Configuration.AppDependencies
{
    public class DependenciesImplementation
    {
        public static void EnableDependencies(IServiceCollection services)
        {
            // Adding the Singleton Instance Service
            services.AddSingleton<IFootballMockService, FootballMockDataService>();
            services.AddSingleton<IFootballTeamService, FootballTeamService>();
        }
    }
}
