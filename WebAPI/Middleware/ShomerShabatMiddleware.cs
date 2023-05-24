using System.Globalization;

namespace WebAPI.Middleware
{
    public class ShomerShabatMiddleware
    {
        //DI
        private readonly RequestDelegate next;

        public ShomerShabatMiddleware(RequestDelegate _next)
        {
            next = _next;
        }
       
        public async Task InvokeAsync(HttpContext context)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                await   context.Response?.WriteAsync("אתר שומר שבת !!");
            else
            // Call the next delegate/middleware in the pipeline.
                 await next(context);

          if  (  context.Response.ContentLength>20000)
                context.Response?.WriteAsync("התגובה גדולה מדי ");

        }

    }

    public static class Ext
    {
        public static IApplicationBuilder  UseShabatMiddleware(this IApplicationBuilder builder)
        {
            return    builder.UseMiddleware<ShomerShabatMiddleware>();
           // return builder;
           //הפונקציה מחזירה את האוביקט שקיבלה כדי לאפשר 
           //fluent API
           //אבל זה לא חובה !!
        }

    }
}
