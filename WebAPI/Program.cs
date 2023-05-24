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
        string connString = builder.Configuration.GetConnectionString(csName) ?? throw new Exception("�� ����� ������ ����� �����");
        builder.Services.AddDbContext<Repository.DbModels.DiaryContext>(op => op.UseSqlServer(connString));

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

        //����� �������
        app.UseAuthorization();
        //����� �� 
        app.MapControllers();
      
        app.Use(middlewareMethod);//inline middleware
         
        // app.Use(async (context, next) =>
        //{
        //    if (DateTime.Now.DayOfWeek ==DayOfWeek.Saturday )
        //        await context.Response.WriteAsync("The site is inactive on saturday");
        //    else
        //    // Do work that can write to the Response.
        //    await next.Invoke();
        //    // Do logging or other work that doesn't write to the Response.
        //});
        //����IApplicationBuilder�����
 
       
        //����� �������� ������
        //����� ����
        //app ?.UseMiddleware<RequestCultureMiddleware>();
        //����� ������� ������� �����

 
        app.UseMiddleware<ShomerShabatMiddleware>();//
       
        app.UseMiddleware<Middleware.RequestCultureMiddleware>();//

        app.UseRequestCulture();
                                                     //��� ������� �����
        app.UseShabatMiddleware();//�������� ����� ������ �����

        //����� ����� �� ��� �� ����� ��������� ����
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
             await   context.Response.WriteAsync ("�� ������ ����� ����");
        else
       // next ();
        next?.Invoke ();
    }
}