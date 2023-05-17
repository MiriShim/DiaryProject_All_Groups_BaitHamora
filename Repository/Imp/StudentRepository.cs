using Repository.DbModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Imp
{
    public class StudentRepository : IStudentRepository
    {
        //todo: move the usage of context to use by DI
        private readonly IDiaryContext ctx;
        public StudentRepository(IDiaryContext diaryContext)
        {
            ctx = diaryContext; 
        }
        public bool AddNew(Student obj)
        {
            try
            {
                // using DiaryContext ctx = new();
                ctx .Add(obj);
                ctx.SaveChanges();
                return true;
            }
            catch 
            { return false; }
        }

        public bool Delete<T>(int id)
        {
            try
            {
                using DiaryContext ctx = new();
                ctx.Remove<Student> (ctx.Find<Student>(id)??
                            throw new Exception($"Entity {nameof (Student )} with id:{nameof(Student.Id)} was not found !!"));
                ctx.SaveChanges();
                return true;
            }
            catch
            { return false; }
        }

        public IEnumerable<Student> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> Get(Func<Group, bool> cond)
        {
            throw new NotImplementedException();
        }

        public Student Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsIncludeGroup()
        {
            throw new NotImplementedException();
        }

        public int Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
