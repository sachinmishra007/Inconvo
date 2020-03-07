using FluentAssertions;
using FootballTeam.Integration.Tests.JWTAuth;
using Footboll.Team.WebApi.Constants;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTeam.Integration.Tests
{
    public class FootballTeamTests : JWTAuthentication
    {
        [Fact]
        public async Task GetAllFootballTeamsSuccessCheck()
        {
            await JWTAuthenticateAsync();
            var _footballTeams = await _client.GetAsync(AppConstants.AppRoutes.GetFootballTeams.Replace(APIVersion,AppConstants.ApiVersion.Version_1_0));
            _footballTeams.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAllFootballTeamsShouldHaveCount()
        {
            await JWTAuthenticateAsync();
            var _footballTeams = await _client.GetAsync(AppConstants.AppRoutes.GetFootballTeams.Replace(APIVersion, AppConstants.ApiVersion.Version_1_0));
            var teamCount = _footballTeams.Content.ReadAsAsync<List<FootballTeam>>().Result;
            teamCount.Should().HaveCountGreaterThan(5);
        }

        [Fact]
        public async Task GetAllFootballTeamsNotBeNull()
        {
            await JWTAuthenticateAsync();
            var _footballTeams = await _client.GetAsync(AppConstants.AppRoutes.GetFootballTeams.Replace(APIVersion, AppConstants.ApiVersion.Version_1_0));
            var teamCount = _footballTeams.Content.ReadAsAsync<List<FootballTeam>>().Result;
            teamCount.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetFootballTeamSuccessCheck()
        {
            await JWTAuthenticateAsync();
            var _footballTeams = await _client.GetAsync(AppConstants.AppRoutes.GetFootballTeam.Replace(APIVersion, AppConstants.ApiVersion.Version_1_0));
            _footballTeams.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Fact]
        public async Task GetFootballTeamSearchForTeam()
        {
            var Test = new FootballTeam()
            {
                Name = "Wolverhampton",
                Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/5543.jpg"
            };
            await JWTAuthenticateAsync();
            var _footballTeams = await _client.GetAsync(AppConstants.AppRoutes.GetFootballTeam.Replace(APIVersion, AppConstants.ApiVersion.Version_1_0).Replace("{footballTeamName}",Test.Name));
            var teamCount = _footballTeams.Content.ReadAsAsync<FootballTeam>().Result;
            teamCount.Name.Should().Be(Test.Name);
            teamCount.Image.Should().Be(Test.Image);
        }

        [Fact]
        public async Task GetFootballTeamNotFound()
        {
            var Test = new FootballTeam()
            {
                Name = "Example",
                Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/5543.jpg"
            };
            await JWTAuthenticateAsync();
            var _footballTeams = await _client.GetAsync(AppConstants.AppRoutes.GetFootballTeam.Replace(APIVersion, AppConstants.ApiVersion.Version_1_0).Replace("{footballTeamName}", Test.Name));
            var teamCount = _footballTeams.Content.ReadAsAsync<FootballTeam>().Result;
            teamCount.Name.Should().Be(Test.Name);
            teamCount.Image.Should().Be(AppConstants.ApplicationMessage.NoRecordFound.ToString());
        }

        [Fact]
        public async Task InsertUpdateFootballTeamSucessCheck()
        {
            var footballTeam = new FootballTeam()
            {
                Name = "Example1",
                Image = "Example1.jpg"
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(footballTeam), 
                Encoding.UTF8, "application/json");

            await JWTAuthenticateAsync();
            var _footballTeams = await _client.PostAsync(AppConstants.AppRoutes.InsertUpdateFootballTeam.Replace(APIVersion, AppConstants.ApiVersion.Version_1_0), stringContent);
            _footballTeams.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task InsertUpdateFootballTeamCheckInsert()
        {
            var footballTeam = new FootballTeam()
            {
                Name = "Example1",
                Image = "Example1.jpg"
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(footballTeam),
                Encoding.UTF8, "application/json");

            await JWTAuthenticateAsync();
            var _footballTeams = await _client.PostAsync(AppConstants.AppRoutes.InsertUpdateFootballTeam.Replace(APIVersion, AppConstants.ApiVersion.Version_1_0), stringContent);
            var teamCount = _footballTeams.Content.ReadAsAsync<APIMessageResponse>().Result;
            teamCount.Message.Should().Be(AppConstants.ApplicationMessage.Inserted);
        }

        [Fact]
        public async Task InsertUpdateFootballTeamCheckUpdate()
        {
            var footballTeam = new FootballTeam()
            {
                Name = "Wolverhampton",
                Image = "Example1.jpg"
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(footballTeam),
                Encoding.UTF8, "application/json");

            await JWTAuthenticateAsync();
            var _footballTeams = await _client.PostAsync(AppConstants.AppRoutes.InsertUpdateFootballTeam.Replace(APIVersion, AppConstants.ApiVersion.Version_1_0), stringContent);
            var teamCount = _footballTeams.Content.ReadAsAsync<APIMessageResponse>().Result;
            teamCount.Message.Should().Be(AppConstants.ApplicationMessage.Updated);
        }
    }
}
