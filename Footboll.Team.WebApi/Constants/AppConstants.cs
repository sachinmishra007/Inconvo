using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Footboll.Team.WebApi.Constants
{
    public static class AppConstants
    {
        public static class ApiVersion
        {
            public const string API = "api";
            public const string Version_1_0 = "1.0";
            public const string footballController = "football";
            public const string AuthController = "auth";
        }
        public static class AppRoutes
        {        
            public const string GetFootballTeams = AppConstants.ApiVersion.API
                +"/v{api-version:apiVersion}/"
                + AppConstants.ApiVersion.footballController + "/GetAllFootballTeams";
            public const string GetFootballTeam = AppConstants.ApiVersion.API 
                + "/v{api-version:apiVersion}/"
                + AppConstants.ApiVersion.footballController + "/GetAllFootballTeam/{footballTeamName}";
            public const string InsertUpdateFootballTeam = AppConstants.ApiVersion.API 
                + "/v{api-version:apiVersion}/"
                + AppConstants.ApiVersion.footballController + "/InsertUpdateFootballTeam/";
            public const string GetAuthToken = AppConstants.ApiVersion.API 
                + "/v{api-version:apiVersion}/"
                + AppConstants.ApiVersion.AuthController + "/token/";
        }

        public static class ServerMessages
        {
            public const string InternalServerError = "Internal Server Error has been occured.";
        }

        public static class ApplicationMessage
        {
            public const string Inserted = "Record is Successfully Inserted";
            public const string Updated = "Record is Successfully Updated";
            public const string NoRecordFound = "No Image Found";
        }

        public static class JWTBearerToken
        {
            public const string Token = "qqqqwertyvushaksnkjshduiy382309283090-s9d0sjdksjdisd9898203920kdklsjdksjd";
            public const string Issuer = "https://localhost:44356/";
            public const string Audience = "http://localhost:4200/";
            public const int Expires = 2;
        }
    }
}
