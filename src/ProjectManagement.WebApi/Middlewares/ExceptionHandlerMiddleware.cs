﻿using ProjectManagement.Modules.AuthUser.Infraestructure.Adapters.Persistence.Errors;
using ProjectManagement.Modules.Commons.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace ProjectManagement.WebApi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly IHostEnvironment _environment;

        public ExceptionHandlerMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlerMiddleware> logger,
            IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
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


        public record ErrorResponse(string Type, string Title, int Status, string? Details = "", Object Message = null);


        private async Task SendContext(HttpContext httpContext, int statusCode, ErrorResponse response)
        {

            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = statusCode;
            var json = JsonSerializer.Serialize(response);

            await httpContext.Response.WriteAsync(json);

        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {

            var errorBodyResponse = new ErrorResponse("", "", 200);
            switch (ex)
            {
                case CustomNotFoundException exception:
                    errorBodyResponse = new ErrorResponse
                   (
                       Title: "The specified resource was not found.",
                       Status: (int)HttpStatusCode.NotFound,
                       Type: "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                       Message: exception.Message
                   ); ;
                    await SendContext(httpContext, (int)HttpStatusCode.NotFound, errorBodyResponse);
                    break;

                    
                case CustomConflictException exception:
                    errorBodyResponse = new ErrorResponse
               (
                   Title: "The specified resource already exists on the server.",
                   Status: (int)HttpStatusCode.Conflict,
                   Type: "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8",
                   Message: exception.Message
               ); ;
                    await SendContext(httpContext, (int)HttpStatusCode.Conflict, errorBodyResponse);
                    break;

                case CustomIdentityErrors exception:
                    errorBodyResponse = new ErrorResponse
               (
                   Title: "Account information does not meet the complexity requirements",
                   Status: (int)HttpStatusCode.BadRequest,
                   Type: "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                   Message: exception.Errors
               ); ;
                    await SendContext(httpContext, (int)HttpStatusCode.BadRequest, errorBodyResponse);
                    break;

                case CustomUnauthorizedException exception:
                    errorBodyResponse = new ErrorResponse
               (
                   Title: "Invalid credentials to access the server.",
                   Status: (int)HttpStatusCode.Unauthorized,
                   Type: "https://www.rfc-editor.org/rfc/rfc9110#section-15.5.2",
                   Message: exception.Message
               ); ;
                    await SendContext(httpContext, (int)HttpStatusCode.Unauthorized, errorBodyResponse);
                    break;



                default:
                    var errorBodyResponseDefault = new ErrorResponse
                    (
                        Title: "An internal server error has occurred",
                        Status: (int)HttpStatusCode.InternalServerError,
                        Type: "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                        Details: _environment.IsDevelopment() ? ex.StackTrace : "",
                        Message: ex.Message
                    );
                    await SendContext(httpContext, (int)HttpStatusCode.InternalServerError, errorBodyResponseDefault);
                    break;
            }


        }
    }





    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalCustomErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
