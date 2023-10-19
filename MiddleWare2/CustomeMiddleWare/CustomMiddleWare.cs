using Microsoft.AspNetCore.Http;
using MiddleWare2.ErrorInfo;
using System.Net;
using System.Text.Json;

namespace MiddleWare2.CustomeMiddleWare
{
    public class CustomMiddleWare : IMiddleware
    {
        private readonly ILogger<CustomMiddleWare> _logger;
        public CustomMiddleWare(ILogger<CustomMiddleWare> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {
                await next(context);
               
            }
            catch (Exception ex)
            {
                var error = new Error
                {
                    StatusCode=500,
                    ErrorMessage=ex.Message,
                };
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = error.StatusCode;
                await context.Response.WriteAsync(error.ToString());
            }
        }

       
    }
    public static class CustomMiddleWareExtention
    {
        public static IApplicationBuilder CustomMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleWare>();
        }
    }
}
