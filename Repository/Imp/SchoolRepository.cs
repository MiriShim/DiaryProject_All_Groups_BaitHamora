using Repository.DbModels;
using Repository.Interfaces;
using System.Linq;
using System.Collections.Generic;
using Repository.Imp;
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Imp;

public class SchoolRepository : ISchoolRepository
{
    private readonly IDiaryContext  context;
    public SchoolRepository(IDiaryContext _context)
    {
        this.context = _context;
    }

    //public  async Task< bool> AddNew(School obj)//בצורה אסינכרונית
    public bool  AddNew(School obj)
    {
        try
        {
            context.Add(obj);
           //await context.SaveChangesAsync(); //בצורה אסינכרונית
            context.SaveChanges();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }
 

    public bool Delete<T>(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<School> Get()
    {
        //using DiaryContext ctx = new();//can use without {} 
        return context.Schools.ToList();
    }

    public IEnumerable<School> Get(Func<Group, bool> cond)
    {
        throw new NotImplementedException();
    }

    public School Get(int id)
    {
        throw new NotImplementedException();
    }

    

    public IEnumerable<School> GetSchoolIncludStudents()
    {
        throw new NotImplementedException();
    }

    public int Update(School entity)
    {
        throw new NotImplementedException();
    }

    bool ICRUD<School>.AddNew(School obj)
    {
        throw new NotImplementedException();
    }
}
