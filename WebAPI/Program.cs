using Microsoft.EntityFrameworkCore;
using Repository.Imp;
using Repository.Interfaces;
using Services;
using Services.ServicesImp;
using System.Globalization;
using WebAPI.Middleware;
using static System.Net.Mime.MediaTypeNames;

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
        builder.Services.AddScoped<IGroupService, GroupServices>();
        builder.Services.AddScoped<IGroupRepository, GroupRepository>();
        
        builder.Services.AddAutoMapper(c => c.AddProfile(typeof(MyMappingProfile)));

        builder.Services.AddLogging(aaa =>
        {
            aaa.AddConsole();
            aaa.AddEventLog();
            aaa.AddDebug();
            aaa.AddFilter("Microsoft.EntityFrameworkCore.Database.Command"
            , LogLevel.Critical);

         });

        string csName = Environment.UserName.StartsWith("st") ? "DiaryDatabaseSchool" : "DiaryDatabaseHome";
        
        string connString = builder.Configuration.GetConnectionString(csName) ?? throw new Exception("ìà ðîöàä îçøåæú çéáåø ú÷éðä");

 
        connString = @"postgres://mirishim:dlbYkcbRlQbpg8DgJRqMiVW5jLNuh5a6@dpg-chp77s67avjb90ia1d10-a.oregon-postgres.render.com/diaryallgroupsdb";

        //מחרוזת החיבור כאשר עובדים מול sql-server מקומי
        //builder.Services.AddDbContext<Repository.DbModels.DiaryContext>(op => op.UseSqlServer(connString));
        //מחרוזת החיבור כאשר עובדים מול postressql בענן
        builder.Services.AddDbContext<DiaryContext>(op => op.UseNpgsql("name=postgresqlconnectionstring"));

        //קריאה לפונקציה בשכבת ה- BL שמוסיפה את התלויות של שכבת bl  שקשורות בדרך כלל ל-dal
        builder.Services.AddBlServices();
       
        //הוספת כל ההרשאות
        builder.Services.AddCors(op=>
            op.AddPolicy("myPolicy",
               a =>
               {
                   a.AllowAnyHeader();
                   a.AllowAnyMethod();
                   a.AllowAnyOrigin();
               }));

        //בניית השרת העצמאי
        WebApplication app = builder.Build();

        app.UseHttpsRedirection();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/error");
        }
       
        app.UseStatusCodePages(async statusCodeContext =>
        {
            // using static System.Net.Mime.MediaTypeNames;
            statusCodeContext.HttpContext.Response.ContentType = Text.Plain;

            await statusCodeContext.HttpContext.Response.WriteAsync(
                $"Status Code Page: {statusCodeContext.HttpContext.Response.StatusCode}");
        });

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseShabatMiddleware();
       
        app.MapControllers();

        app.UseRouting();

               
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
         
        #region middlewares

        app.Use(async (context, next) =>
        {
            string?  cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;

            }

            // Call the next delegate/middleware in the pipeline.
            await next(context);
        });

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

 
        //áìé ôåð÷öéú äøçáä
        //  app.UseShabatMiddleware();//ôåð÷öéåú äøçáä ùàðçðå éöøðå

        //ãåâîà ìäøöä ùì àúø òí úâåáä è÷ñèåàìéú áìáã
        //app.Run(async context =>
        //{
        //    //a single anonymous function is called in response to every HTTP request:
        //    await context.Response.WriteAsync("Our sit is at build. Thank you !");
        //});
        #endregion 

        app.UseCors("policy");

        app.Run();
    }

    private static async Task middlewareMethod(HttpContext context, Func<Task> next)
    {
        if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
             await   context.Response.WriteAsync ("ìà ðåúðéí ùéøåú áùáú");
        else
       // next ();
        next?.Invoke ();
    }
}