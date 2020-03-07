using Football.Team.BussinessLogic.Interfaces;
using Football.Team.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Team.BussinessLogic.Repositories
{
    public class FootballMockDataService : IFootballMockService
    {
        public List<FootballTeam> _mockFootballTeams =  null;

        List<FootballTeam> IFootballMockService._mockFootballTeams
        {
            get => _mockFootballTeams;
            set => GetMockFootballData();
        }

        public FootballMockDataService()
        {
            //Geeting the Mock Data for the Football
            GetMockFootballData();
        }
        public List<FootballTeam> GetMockFootballTeams()
        {
            return _mockFootballTeams;
        }

        public void GetMockFootballData()
        {
            _mockFootballTeams = new List<FootballTeam>()
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
                    },
                        new FootballTeam() {
                    Name =  "Liverpool",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/646.jpg"
                    },
                        new FootballTeam() {
                    Name =  "Leicester City",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/633.jpg"
                    },
                        new FootballTeam() {
                    Name =  "Manchester City",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/642.jpg"
                    },
                        new FootballTeam() {
                    Name =  "Newcastle United",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/2463.jpg"
                    },
                        new FootballTeam() {
                    Name =  "Wolverhampton",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/5543.jpg"
                    },
                        new FootballTeam() {
                    Name =  "Tottenham Hotspur",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/648.jpg"
                    },
                        new FootballTeam() {
                    Name =  "Southampton",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/647.jpg"
                    },
                        new FootballTeam() {
                    Name =  "West Ham United",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/640.jpg"
                    },
                    new FootballTeam() {
                    Name =  "Watford",
                    Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/638.jpg"
                    }
            };
        }

    }
}
