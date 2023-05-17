using Microsoft.EntityFrameworkCore;
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
  
    public class GroupRepository :  IGroupDAL
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
                 return context.Groups.Find(id);
                 
            }
            catch
            {
                return null;
            }
        }

        public Group?  GetGroupDetailed(int id)
        {
            using DiaryContext ctx = new();
            try
            {
                // return ctx.Groups.Include("School").Single(g=>g.Id == id);
                  return ctx.Groups.Include(a=>a.School  ).SingleOrDefault(g=>g.Id == id);
                // var a= ctx.Groups.Where (i=>i.Id==id).Select(g => new() { g.Id, g.Name, g.School.Name });  // .Single(g=>g.Id == id);
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

        public IEnumerable<Group> GetGroupsWithSchool()
        {
            throw new NotImplementedException();
        }
    }
}
