using Football.Team.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Team.BussinessLogic.Interfaces
{
    public interface IFootballMockService
    {
        List<FootballTeam> _mockFootballTeams { get; set; }
        List<FootballTeam> GetMockFootballTeams();
    }
}
