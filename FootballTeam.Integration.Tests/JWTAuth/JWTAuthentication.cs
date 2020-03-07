using Footboll.Team.WebApi;
using Footboll.Team.WebApi.Constants;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeam.Integration.Tests.JWTAuth
{
    public class JWTAuthentication
    {
        protected const string APIVersion = "{api-version:apiVersion}";

        protected readonly HttpClient _client;

        public JWTAuthentication()
        {
            var _appFactory = new WebApplicationFactory<Startup>();
            _client = _appFactory.CreateClient();
        }

        protected async Task JWTAuthenticateAsync()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        private async Task<string> GetJwtAsync()
        {
            var tokenResponse = await _client.GetAsync(AppConstants.AppRoutes.GetAuthToken.Replace(APIVersion,AppConstants.ApiVersion.Version_1_0));
            return tokenResponse.Content.ReadAsStringAsync().Result;
        }
    }
}
