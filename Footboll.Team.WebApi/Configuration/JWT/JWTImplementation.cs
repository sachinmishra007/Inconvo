﻿using Footboll.Team.WebApi.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footboll.Team.WebApi.Configuration
{
    public class JWTImplementation
    {
        public static void EnablingJWTAuthentication(IServiceCollection services)
        {
            var SecretKey = Encoding.ASCII.GetBytes(AppConstants.JWTBearerToken.Token);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(token =>
            {
                //token.RequireHttpsMetadata = false;
                //token.SaveToken = true;
                token.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(SecretKey),
                    ValidateIssuer = false,
                    ValidIssuer = AppConstants.JWTBearerToken.Issuer,
                    ValidateAudience = false,
                    ValidAudience = AppConstants.JWTBearerToken.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                token.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
