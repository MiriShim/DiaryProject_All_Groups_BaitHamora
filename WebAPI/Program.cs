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
using Middleware.Example;

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
        builder.Services.AddScoped<IUnitService,UnitServices >();
 
        builder.Services.AddAutoMapper(c=>c.AddProfile (typeof(MyMappingProfile )));

        string csName = Environment.UserName.StartsWith("st") ? "DiaryDatabaseSchool" : "DiaryDatabaseHome";
        string connString = builder.Configuration.GetConnectionString(csName) ?? throw new Exception("לא נמצאה מחרוזת חיבור תקינה");
        builder.Services.AddDbContext<Repository.DbModels.DiaryContext>(op => op.UseSqlServer(connString));

       //builder.Services.AddDbContext<Repository.DbModels.DiaryContext >(options =>
       //    options.UseSqlServer(builder.Configuration.GetConnectionString("DiaryDatabase"))) ;
        
        builder.Services.AddBlServices();



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.MapControllers();
        //דוגמא למידלוור
        app.Use(async (context, next) =>
        {
            if (DateTime.Now.DayOfWeek ==DayOfWeek.Saturday )
                await context.Response.WriteAsync("The site is inactive on saturday");
            else
            // Do work that can write to the Response.
            await next.Invoke();
            // Do logging or other work that doesn't write to the Response.
        });
        //דוגמא למידלוור
        app.Use(async (context, next) =>
        {
            var cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            // Call the next delegate/middleware in the pipeline.
            await next(context);
        });
        //שליחה למידלוור שיצרנו
        //שימוש פשוט
        //app ?.UseMiddleware<RequestCultureMiddleware>();
        //שימוש באמצעות פונקצית הרחבה
        app.UseRequestCulture();

        //דוגמא להרצה של אתר עם תגובה טקסטואלית בלבד
        //app.Run(async context =>
        //{
        //    //a single anonymous function is called in response to every HTTP request:
        //    await context.Response.WriteAsync("Our sit is at build. Thank you !");
        //});


        app.Run();
    }
}