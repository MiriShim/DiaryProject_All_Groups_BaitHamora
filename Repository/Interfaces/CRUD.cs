using Repository.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    //crud: create read update delete
    public  interface CRUD<T>
    {
        bool AddNew (T obj);
        bool Delete <T>(int id );
        int Update(T entity);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<Group, bool> cond);
        T Get(int id);
    }
}
