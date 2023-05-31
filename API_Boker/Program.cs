using API_Boker.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Configuration;
using Repository.DbModels;
using Repository.Imp;
using Repository.Interfaces;
using Services.ServiceAPI;
using Services.ServicesImp;

namespace API_Boker
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();

            var logger = LoggerFactory.Create(config =>
            {
                config.AddConsole();
                builder.Logging.AddDebug();

            }).CreateLogger("Program");


            //builder.Logging.AddConsole();
            // builder.Logging.AddEventLog();
            builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command"
                , LogLevel.Information);
            
            builder.Services.AddLogging();
            // Add this line to set the logging level for Entity Framework Core
            

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            // Add this line to register your controller with the dependency injection system
            builder.Services.AddScoped<GroupController>(); 

            builder.Services.AddScoped(typeof(ISchoolService), typeof(SchoolService));
            builder.Services.AddScoped(typeof(ISchoolRepository), typeof(SchoolRepository));
            //
            builder.Services.AddScoped(typeof(IStudentService),typeof(StudentService)); 
            builder.Services.AddScoped(typeof(IStudentRepository ),typeof(StudentRepository )); 

            builder.Services.AddScoped(typeof(IGroupService ),typeof(GroupServices )); 
            builder.Services.AddScoped(typeof(IGroupRepository ),typeof( GroupRepository   )); 

            builder.Services.AddScoped(typeof(ICRUD<Group> ), typeof(Repository.Imp.GroupRepository ));
            builder.Services.AddScoped(typeof(ICRUD<Unit> ), typeof(Repository.Imp.UnitDAL ));
            builder.Services.AddScoped(typeof(IUnitService), typeof(UnitServices));
           
            builder.Services.AddScoped(typeof(IDiaryContext), typeof(DiaryContext));
             
            string connStrConfigName = Environment.UserName switch 
            { 
                "mora2" or "talmid2" => "SharanskiConnection",
                "st45" => "SeminarOfakimConnection",
                "Miriam"  => "HomeConnection", 
                _  => "HomeConnection" 
            };

            builder.Services.AddDbContext<DiaryContext>(
                 optionB => optionB.UseSqlServer($"name=ConnectionStrings:{connStrConfigName}"));

            //       => optionsBuilder.UseSqlServer("Server=.;Database=diary;Trusted_Connection=True;trustserverCertificate=true");
            //        => optionsBuilder.UseSqlServer("Data Source=FSQLN\\FSQLN;Initial Catalog=Diary_YomAroch_5783;Integrated Security=True;trustservercertificate=true");
            //  builder.Services.AddScoped(typeof(Repository.Interfaces.IUnitDal ), typeof(Repository.Imp.UnitDAL));
            //==========mapper::
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperConfig ());
            });

            IMapper mapper = mapperConfig.CreateMapper();         

            builder.Services.AddSingleton(mapper);
             
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

            app.Run();
        }
    }
}