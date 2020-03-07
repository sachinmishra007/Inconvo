using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football.Team.BussinessLogic.Interfaces;
using Football.Team.Entities.Entities;
using Footboll.Team.WebApi.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Footboll.Team.WebApi.Controllers
{ 
    [ApiVersion(AppConstants.ApiVersion.Version_1_0)]
    [ApiController]
    [Authorize]
    public class FootballTeamController : ControllerBase
    {
        private readonly IFootballTeamService _fbTeamService = null;
        public FootballTeamController(
            IFootballTeamService fbTeamService
            )
        {
            this._fbTeamService = fbTeamService;
        }
        
        
        [HttpGet(AppConstants.AppRoutes.GetFootballTeams)]
        public ActionResult<List<FootballTeam>> Get()
        {
            return this._fbTeamService.GetAllFootballTeams();
        }


        [HttpGet(AppConstants.AppRoutes.GetFootballTeam)]
        public ActionResult<object> Get(string footballTeamName)
        {
            return this._fbTeamService.GetFootballTeam(footballTeamName);
        }

        [HttpPost(AppConstants.AppRoutes.InsertUpdateFootballTeam)]
        public ActionResult<APIMessageResponse> Post([FromBody] FootballTeam _footballTeam)
        {
            return this._fbTeamService.InsertUpdateTeamsInfo(_footballTeam);
        }

    }
}
