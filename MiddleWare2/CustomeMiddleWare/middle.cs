using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddleWare2.CustomeMiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class middle
    {
        private readonly RequestDelegate _next;

        public middle(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class middleExtensions
    {
        public static IApplicationBuilder Usemiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<middle>();
        }
    }
}
