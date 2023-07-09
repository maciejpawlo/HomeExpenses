using System.Net;
using FluentValidation;
using HomeExpenses.Tracking.Application.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HomeExpenses.Tracking.API.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ProblemDetailsFactory problemDetailsFactory;

        public ExceptionMiddleware(ProblemDetailsFactory problemDetailsFactory) 
        {
            this.problemDetailsFactory = problemDetailsFactory;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            switch (ex)
            {
                case NotFoundException notFoundException:
                    {
                        var problemDetails = problemDetailsFactory.CreateProblemDetails(httpContext,
                            statusCode: (int)HttpStatusCode.NotFound, detail: notFoundException.Message);
                        await httpContext.Response.WriteAsJsonAsync(problemDetails);
                        break;
                    }
                case ValidationException validationException:
                    {
                        var modelStateDictionary = new ModelStateDictionary();
                        foreach (var error in validationException.Errors)
                        {
                            modelStateDictionary.AddModelError(error.PropertyName, error.ErrorMessage);
                        }
                        var problemDetails = problemDetailsFactory.CreateValidationProblemDetails(httpContext, modelStateDictionary);
                        await httpContext.Response.WriteAsJsonAsync(problemDetails);
                        break;
                    }
                default:
                    {
                        var problemDetails = problemDetailsFactory.CreateProblemDetails(httpContext);
                        await httpContext.Response.WriteAsJsonAsync(problemDetails);
                        break;
                    }
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
