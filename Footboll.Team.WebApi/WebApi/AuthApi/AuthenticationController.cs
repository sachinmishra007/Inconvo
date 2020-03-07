using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Footboll.Team.WebApi.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Footboll.Team.WebApi.WebApi.AuthApi
{
    [ApiController]
    [ApiVersion(AppConstants.ApiVersion.Version_1_0)]   
    public class AuthenticationController : ControllerBase
    {
        [HttpGet(AppConstants.AppRoutes.GetAuthToken)]
        public ActionResult<string> Token()
        {
            //var header = Request.Headers["Authorization"];
            //var credValue = header.ToString().Substring("Basci ".Length).Trim();
            //var userNameAndPassenc = Encoding.UTF8.GetString(Convert.FromBase64String(credValue));
            //var userNameAndPass = userNameAndPassenc.Split(":");
            var claims = new[] {
                new Claim(ClaimTypes.Name,"username")
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(AppConstants.JWTBearerToken.Token));

            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                key, SecurityAlgorithms.HmacSha256Signature);
            var tokennString = new JwtSecurityToken(
                issuer: AppConstants.JWTBearerToken.Issuer,
                audience: AppConstants.JWTBearerToken.Audience,
                expires: DateTime.Now.AddMinutes(AppConstants.JWTBearerToken.Expires),
                claims: claims,
                signingCredentials: signingCredentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokennString);
            return token;
        }
    }
}