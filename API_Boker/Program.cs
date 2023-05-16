
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.DbModels;
using Repository.Imp;
using Repository.Interfaces;
using Services.ServiceAPI;
using Services.ServicesImp;

namespace API_Boker
{
    public class Program
    {//==================328471867
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //
            builder.Services.AddScoped(typeof(IStudentService),typeof(StudentService)); 
            builder.Services.AddScoped(typeof(IStudentRepository ),typeof(StudentRepository )); 

            builder.Services.AddScoped(typeof(IGroupService), typeof(GroupServices));
            builder.Services.AddScoped(typeof(Repository.Interfaces.CRUD<Group> ), typeof(Repository.Imp.GroupDAL ));
            builder.Services.AddScoped(typeof(Repository.Interfaces.CRUD<Unit> ), typeof(Repository.Imp.UnitDAL ));
            builder.Services.AddScoped(typeof(IUnitService), typeof(UnitServices));
            builder.Services.AddScoped(typeof(Repository.Interfaces.IDiaryContext), typeof(DiaryContext));

            builder.Services.AddDbContext<DiaryContext>(
                 optionB => optionB.UseSqlServer("name=ConnectionStrings:HomeConnection"));

            //       => optionsBuilder.UseSqlServer("Server=.;Database=diary;Trusted_Connection=True;trustserverCertificate=true");
            //        => optionsBuilder.UseSqlServer("Data Source=FSQLN\\FSQLN;Initial Catalog=Diary_YomAroch_5783;Integrated Security=True;trustservercertificate=true");
            //  builder.Services.AddScoped(typeof(Repository.Interfaces.IUnitDal ), typeof(Repository.Imp.UnitDAL));
            //==========mapper::
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new  MapperConfig ());
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