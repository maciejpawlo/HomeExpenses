using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace HomeExpenses.Tracking.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next) 
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            ProblemDetails problemDetails = new();
            ValidationProblemDetails validationProblemDetails = new();

            httpContext.Response.ContentType = "application/json";
            switch (ex)
            {
                case ValidationException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 
                    break;
            }
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
