using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware111
    {
        private readonly RequestDelegate _next;

        public Middleware111(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    //public static class Middleware111Extensions
    //{
    //    public static IApplicationBuilder UseMiddleware111(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<Middleware111>();
    //    }
    //}
}
