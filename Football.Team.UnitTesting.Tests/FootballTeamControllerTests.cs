using FluentAssertions;
using Football.Team.Entities.Entities;
using Footboll.Team.WebApi.Constants;
using Footboll.Team.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Football.Team.UnitTesting.Tests
{
    public class FootballTeamControllerTests
    {
        FootballTeamController _controller;
        FootballTeamFakeService _service;
        public FootballTeamControllerTests()
        {
            _service = new FootballTeamFakeService();
            _controller = new FootballTeamController(_service);
        }

        [Fact]
        public void GetAllFootballTeams()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            okResult.Value.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetAllFootballTeamsHaveCounts()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            okResult.Value.Should().HaveCountGreaterThan(5);
        }

        [Fact]
        public void GetFootballTeamSingleNotFound()
        {
            //Arrange
            string footballTeam = "Example";

            // Act
            var okResult = _controller.Get(footballTeam).Value as FootballTeam;

            // Assert
            okResult.Name.Should().Be(footballTeam);
            okResult.Image.Should().Be(AppConstants.ApplicationMessage.NoRecordFound);
        }

        [Fact]
        public void GetFootballTeamSingleFound()
        {
            //Arrange
            string footballTeam = "Wolverhampton";

            // Act
            var okResult = _controller.Get(footballTeam).Value as FootballTeam;

            // Assert
            okResult.Name.Should().NotBeNullOrEmpty();
            okResult.Image.Should().NotBeNullOrEmpty();
        }
        [Fact]
        public void InsertUpdateFootballTeamCheckInsert()
        {
            //Arrange
            var footballTeam = new FootballTeam()
            {
                Image="Example.jpg",
                Name="Example"
            };
            // Act
            var okResult = _controller.Post(footballTeam).Value as APIMessageResponse;
            //Assert
            okResult.Message.Should().Be(AppConstants.ApplicationMessage.Inserted);
        }

        [Fact]
        public void InsertUpdateFootballTeamCheckUpdate()
        {
            //Arrange
            var footballTeam = new FootballTeam()
            {
                Name = "Arsenal",
                Image = "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/632.jpg"
            };
            // Act
            var okResult = _controller.Post(footballTeam).Value as APIMessageResponse;
            //Assert
            okResult.Message.Should().Be(AppConstants.ApplicationMessage.Updated);
        }
    }
}
