using Football.Team.Entities.Entities;
using Footboll.Team.WebApi.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Footboll.Team.WebApi.ExceptionHandling
{
    public class ExceptionHandler
    {
        // We can implement the data base logging mechanism as well.
        private readonly RequestDelegate _next;
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {              
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorInfo()
            {
                StatusCode = context.Response.StatusCode,
                Message = AppConstants.ServerMessages.InternalServerError
            }.ToString());
        }
    }
}
