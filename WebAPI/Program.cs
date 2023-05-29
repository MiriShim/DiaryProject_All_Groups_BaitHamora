using AutoMapper;
//using Microsoft.Extensions.Configuration;
using Services.ServiceAPI;
using Services.ServicesImp;
using Microsoft.EntityFrameworkCore;
using Services;
using Microsoft.IdentityModel.Abstractions;
using Repository.Interfaces;
using Repository.Imp;
using System.Globalization;
using WebAPI.Middleware;
using Npgsql;
using Repository.DbModels;

namespace WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        // builder.Services.AddScoped(typeof( IUnitService ),typeof( UnitServices));
        builder.Services.AddScoped<IUnitService, UnitServices>();

        builder.Services.AddAutoMapper(c => c.AddProfile(typeof(MyMappingProfile)));

        string csName = Environment.UserName.StartsWith("st") ? "DiaryDatabaseSchool" : "DiaryDatabaseHome";
        
        string connString = builder.Configuration.GetConnectionString(csName) ?? throw new Exception("לא נמצאה מחרוזת חיבור תקינה");

       // var connectionstring = _configuration.GetConnectionString("prattleDatabase");
 
        connString = "postgres://mirishim:dlbYkcbRlQbpg8DgJRqMiVW5jLNuh5a6@dpg-chp77s67avjb90ia1d10-a.oregon-postgres.render.com/diaryallgroupsdb";
        connString = @"host=dpg-chp77s67avjb90ia1d10-a.oregon-postg\r\nres.render.com port=5432 dbname=diaryallgroupsdb user=mirishim sslmode=prefer connect_timeout=10";
        connString = @"postgres://mirishim:dlbYkcbRlQbpg8DgJRqMiVW5jLNuh5a6@dpg-chp77s67avjb90ia1d10-a.oregon-postgres.render.com/diaryallgroupsdb";
      

        //builder.Services.AddDbContext<Repository.DbModels.DiaryContext>(op => op.UseSqlServer(connString));
        builder.Services.AddDbContext<DiaryContext>(op => op.UseNpgsql("name=PostresqlConnectionString"));

        //builder.Services.AddDbContext<Repository.DbModels.DiaryContext >(options =>
        //    options.UseSqlServer(builder.Configuration.GetConnectionString("DiaryDatabase"))) ;

        builder.Services.AddBlServices();
 
        builder.Services.AddCors(op=>
        op.AddPolicy("myPolicy",
           a =>
           {
               a.AllowAnyHeader();
               a.AllowAnyMethod();
               a.AllowAnyOrigin();
           }));

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection()
        //    .UseAuthentication()
        //    .UseRequestCulture()
        //    .UseShabatMiddleware();

        //אימות משתמשים
        app.UseAuthorization();
        //מיפוי של 
        app.MapControllers();
      
        //app.Use(middlewareMethod);//inline middleware
         
        // app.Use(async (context, next) =>
        //{
        //    if (DateTime.Now.DayOfWeek ==DayOfWeek.Saturday )
        //        await context.Response.WriteAsync("The site is inactive on saturday");
        //    else
        //    // Do work that can write to the Response.
        //    await next.Invoke();
        //    // Do logging or other work that doesn't write to the Response.
        //});
        //דוגמIApplicationBuilderדלוור

        app.UseRouting();
        //   // Summary:
        //     Adds a Microsoft.AspNetCore.Routing.EndpointMiddleware middleware to the specified
        //     Microsoft.AspNetCore.Builder.IApplicationBuilder with the Microsoft.AspNetCore.Routing.EndpointDataSource
        //     instances built from configured Microsoft.AspNetCore.Routing.IEndpointRouteBuilder.
        //     The Microsoft.AspNetCore.Routing.EndpointMiddleware will execute the Microsoft.AspNetCore.Http.Endpoint
        //     associated with the current request.
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "blog",
                pattern: "blog/{year}/{month}/{day}/{slug}",
                defaults: new { controller = "Blog", action = "Post" });
        });
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
        //app.Use(async (context, next) =>
        //{
        //    var cultureQuery = context.Request.Query["culture"];
        //    if (!string.IsNullOrWhiteSpace(cultureQuery))
        //    {
        //        var s = (CultureInfo.CurrentCulture);
        //        var culture = new CultureInfo(cultureQuery);

        //        CultureInfo.CurrentCulture = culture;
        //        CultureInfo.CurrentUICulture = culture;
        //    }

        //    // Call the next delegate/middleware in the pipeline.
        //    await next(context);
        //});

        //app.Use(async (context, next) =>
        //{
        //    // Do work that can write to the Response.
        //    if (DateTime.Now.DayOfWeek == DayOfWeek.Friday  )
        //        context.Response.WriteAsync("On Tuesday we dont serve");
        //    else
        //        await next();//.Invoke();
        //        //await next?.Invoke();            
        //    // Do logging or other work that doesn't write to the Response.
        //});


        //שליחה למידלוור שיצרנו
        //שימוש פשוט
        //app ?.UseMiddleware<RequestCultureMiddleware>();
        //שימוש באמצעות פונקצית הרחבה

 
      //  app.UseMiddleware<ShomerShabatMiddleware>();//
       
      //  app.UseMiddleware<Middleware.RequestCultureMiddleware>();//

      //  app.UseRequestCulture();
                                                     //בלי פונקצית הרחבה
      //  app.UseShabatMiddleware();//פונקציות הרחבה שאנחנו יצרנו

        //דוגמא להרצה של אתר עם תגובה טקסטואלית בלבד
        //app.Run(async context =>
        //{
        //    //a single anonymous function is called in response to every HTTP request:
        //    await context.Response.WriteAsync("Our sit is at build. Thank you !");
        //});

        app.UseCors("policy");
        app.Run();
    }

    private static async Task middlewareMethod(HttpContext context, Func<Task> next)
    {
        if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
             await   context.Response.WriteAsync ("לא נותנים שירות בשבת");
        else
       // next ();
        next?.Invoke ();
    }
}