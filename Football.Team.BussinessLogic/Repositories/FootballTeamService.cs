using Football.Team.BussinessLogic.Interfaces;
using Football.Team.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Team.BussinessLogic.Repositories
{
    public class FootballTeamService : IFootballTeamService
    {
        private readonly IFootballMockService _fbMockService = null;
        public FootballTeamService(
            IFootballMockService fbMockService
            )
        {
            this._fbMockService = fbMockService;
        }

        /// <summary>
        ///  Get All the Football Team Info
        /// </summary>
        /// <returns></returns>
        public List<FootballTeam> GetAllFootballTeams()
        {
            return this._fbMockService.GetMockFootballTeams();
        }

        /// <summary>
        ///  Get A Single Football Team Info
        /// </summary>
        /// <param name="_footballTeam"></param>
        /// <returns></returns>
        public FootballTeam GetFootballTeam(string _footballTeam)
        {
            var _serachForTeam = this._fbMockService._mockFootballTeams.Find(a => a.Name.ToLower().Equals(_footballTeam.ToLower()));
            return _serachForTeam == null ? new FootballTeam() { Name = _footballTeam, Image = "No Image Found" } : _serachForTeam;

        }

        /// <summary>
        ///  Insert and Update the Teams Info
        /// </summary>
        /// <param name="_teams"></param>
        /// <returns></returns>
        public APIMessageResponse InsertUpdateTeamsInfo(FootballTeam _teams)
        {
            var _serachForTeam = this._fbMockService._mockFootballTeams.
                FindIndex(a => a.Name.ToLower().Equals(_teams.Name.ToLower()));
            var _message = string.Empty;
            if (_serachForTeam == -1)
            {
                this._fbMockService._mockFootballTeams.Add(_teams);
                _message = "Record is Successfully Inserted";
            }
            else
            {
                this._fbMockService._mockFootballTeams[_serachForTeam] = _teams;
                _message = "Record is Successfully Updated";
            }
            return new APIMessageResponse()
            {
                Message =  _message,
                ResultCount = $"{this._fbMockService._mockFootballTeams.Count + 1} Row's affected"
            };
        }
    }
}
