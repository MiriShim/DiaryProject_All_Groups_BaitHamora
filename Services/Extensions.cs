using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.DbModels;
using Repository.Imp;
using Repository.Interfaces;

namespace Services
{
    public static  class Extensions
    {
        public static void AddBlServices( this  IServiceCollection services)
        {
            services.AddScoped<IUnitDal, UnitDAL>();
            services.AddScoped<IDiaryContext, DiaryContext>();

            // services.AddDbContext<Repository.DbModels.DiaryContext>(options =>
            // options.UseSqlServer( Configuration.GetConnectionString("DiaryDatabase")));

        }
    }
}