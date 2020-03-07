using Football.Team.BussinessLogic.Interfaces;
using Football.Team.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Team.UnitTesting.Tests
{
    public class FootballTeamFakeService : IFootballTeamService
    {
        private readonly List<FootballTeam> footballTeams;
        public FootballTeamFakeService()
        {
            footballTeams = new List<FootballTeam>()
            {
                new FootballTeam(){
                    Name ="Arsenal",
                    Image ="https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/632.jpg"
                    },
                new FootballTeam() {
                    Name="Bournemouth",
                    Image="https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/631.jpg"
                    },
                 new FootballTeam() {
                    Name =  "Brighton & Hove Albion",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/2465.jpg"
                    },
                        new FootballTeam() {
                    Name =  "Burnley",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/650.jpg"
                    },
                        new FootballTeam() {
                    Name =  "Cardiff City",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/5542.jpg"
                    },
                        new FootballTeam() {
                    Name =  "Chelsea",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/635.jpg"
                    },
                        new FootballTeam() {
                    Name =  "Crystal Palace",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/637.jpg"
                    },
                        new FootballTeam() {
                    Name =  "Everton",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/639.jpg"
                    },
                        new FootballTeam() {
                    Name =  "Fulham",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/5770.jpg"
                    },
                        new FootballTeam() {
                    Name =  "Huddersfield Town",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/2464.jpg"
                    },
                        new FootballTeam() {
                    Name =  "Manchester United",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/645.jpg"
                    }
                     
            };
        }

        /// <summary>
        ///  Get All the Football Team Info
        /// </summary>
        /// <returns></returns>
        public List<FootballTeam> GetAllFootballTeams()
        {
            return footballTeams;
        }

        /// <summary>
        ///  Get A Single Football Team Info
        /// </summary>
        /// <param name="_footballTeam"></param>
        /// <returns></returns>
        public FootballTeam GetFootballTeam(string _footballTeam)
        {
            var _serachForTeam = this.footballTeams.Find(a => a.Name.ToLower().Equals(_footballTeam.ToLower()));
            return _serachForTeam == null ? new FootballTeam() { Name = _footballTeam, Image = "No Image Found" } : _serachForTeam;

        }

        /// <summary>
        ///  Insert and Update the Teams Info
        /// </summary>
        /// <param name="_teams"></param>
        /// <returns></returns>
        public APIMessageResponse InsertUpdateTeamsInfo(FootballTeam _teams)
        {
            var _serachForTeam = footballTeams.
                FindIndex(a => a.Name.ToLower().Equals(_teams.Name.ToLower()));
            var _message = string.Empty;
            if (_serachForTeam == -1)
            {
                footballTeams.Add(_teams);
                _message = "Record is Successfully Inserted";
            }
            else
            {
                footballTeams[_serachForTeam] = _teams;
                _message = "Record is Successfully Updated";
            }
            return new APIMessageResponse()
            {
                Message = _message,
                ResultCount = $"{footballTeams.Count + 1} Row's affected"
            };
        }
    }
}
