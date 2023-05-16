using Repository.DbModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Imp
{
    public class GroupDAL : Interfaces.CRUD<DbModels.Group>
    {
        private readonly IDiaryContext context;

        public GroupDAL(IDiaryContext ctx)
        {
            context = ctx;
            
        }
        //todo: dbcontext by DI
        public bool AddNew(Group obj)
        {
            using DiaryContext ctx = new();

            try
            {
                ctx.Groups.Add(obj);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete<T>(int id)
        {
            using DiaryContext ctx = new();
            try
            {
                var g = ctx.Groups.Find(id);
                ctx.Groups.Remove(g);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public  Group  Get(int id)
        {
            using DiaryContext ctx = new();
            try
            {
                return ctx.Groups.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Group> Get()
        {
            try
            {
                return context.Groups.ToList() ;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Group> Get(Func<Group, bool>  cond)
        {
            Func<Group,bool> func = a => a.Id > 100;

            try
            {
                return context .Groups.Where(cond);
            }
            catch
            {
                return null;
            }
        }

        public int Update(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
