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
    public class GroupRepository : IGroupRepository // Interfaces.ICRUD<DbModels.Group>
    {
        private readonly IDiaryContext context;

        public GroupRepository(IDiaryContext ctx)
        {
            context = ctx;
            
        }
        //todo: dbcontext by DI
        public bool AddNew(Group obj)
        {
             
            try
            {
                context.Groups.Add(obj);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete<T>(int id)
        {
            
            try
            {
                var g = context.Groups.Find(id);
                context.Groups.Remove(g);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public  Group  Get(int id)
        {
            
            try
            {
                return context.Groups.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public object GetDeatild(int id)
        {
             
            try
            {
                return context.Groups.Select(g=>new {g.Id,g.Name  ,SchoolName= g.School.Name   }) .Where (i=>i.Id== id);
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
