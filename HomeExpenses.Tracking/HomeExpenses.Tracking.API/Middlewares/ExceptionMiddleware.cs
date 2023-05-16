using System.Collections.Specialized;
using System.Net;

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
            switch (ex)
            {
                default:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 
                    break;
            }
        }
    }
}
