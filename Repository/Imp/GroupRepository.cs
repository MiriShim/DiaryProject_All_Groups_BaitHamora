using Microsoft.EntityFrameworkCore;
using Repository.DbModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Imp
{
  
    public class GroupRepository :  IGroupRepository
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
        public  Group?  Get(int id)
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

        //public IEnumerable<Group> GetGroupsWithSchool()
        //{
        //    throw new NotImplementedException();
        //}

        public object GetDeatild(int  id)
        {
             return context.Groups.Include( g => g.School).SingleOrDefault(g => g.Id == id);
        }
    }
}
