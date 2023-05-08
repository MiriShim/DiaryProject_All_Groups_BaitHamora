
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Services.ServiceAPI;
using Services.ServicesImp;

namespace API_Boker
{
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
            //
            builder.Services.AddScoped(typeof(IGroupService), typeof(GroupServices));
            builder.Services.AddScoped(typeof(IUnitService), typeof(IUnitService));
            builder.Services.AddScoped(typeof(Repository.Interfaces.IUnitDal ), typeof(Repository.Imp.UnitDAL));
             //==========mapper::
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new API_Boker.MapperConfig ());
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