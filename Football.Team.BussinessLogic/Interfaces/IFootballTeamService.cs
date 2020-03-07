using Football.Team.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Team.BussinessLogic.Interfaces
{
    public interface IFootballTeamService
    {
        List<FootballTeam> GetAllFootballTeams();

        FootballTeam GetFootballTeam(string _footballTeam);

        APIMessageResponse InsertUpdateTeamsInfo(FootballTeam _teams);
    }
}
