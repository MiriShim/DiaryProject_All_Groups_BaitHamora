using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Repository.DbModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Imp
{
    public class UnitDAL: ICRUD<Unit >  //IUnitDal
    {
        private readonly IDiaryContext  _dbContext;
        public UnitDAL(IDiaryContext  dbContext)
        {
            _dbContext= dbContext;  
        }
        public List<Unit> GetAll()
        {
            return _dbContext.Units .ToList();
        }

        public async void Save(Unit unit)
        {
            _dbContext.Units.Update  (unit);

            
            _dbContext.SaveChanges();
        }

        public void learnStates()
        {
            DiaryContext ctx = new();

            Unit u1 = ctx.Units.Find(6);
            var state = ctx.Entry<Unit>(u1).State ;

            var prevYear = ctx.Units.TemporalAsOf(DateTime.Today.AddYears(-1));
            //var prev11 = ctx.Units.TemporalAll<Unit >( ).Where(a=> );
            var prev22 = ctx.Units.TemporalAsOf(DateTime.Today.AddYears(-1));

            var history = ctx.Units .TemporalAll().Where(emp => emp.Id == 2)
              .OrderByDescending(emp => EF.Property<DateTime>(emp, "PeriodStart"))
              .Select(emp => new {
                  Employee = emp,
                  PeriodStart = EF.Property<DateTime>(emp, "PeriodStart"),
                  PeriodEnd = EF.Property<DateTime>(emp, "PeriodEnd")
              }).ToList();



            ctx.SaveChanges();
        }

        public bool AddNew(Unit obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete<T>(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Unit entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Unit> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Unit> Get(Func<Group, bool> cond)
        {
            throw new NotImplementedException();
        }

        public Unit Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
