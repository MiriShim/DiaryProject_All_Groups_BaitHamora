using Repository.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces;

//crud: create read update delete
public interface ICRUD<T>
{
    bool AddNew (T obj);
    bool Delete<T>(int id );
    int Update(T entity);
    IEnumerable<T> Get();
    //לא חובה. זו העמסה של הפונקציה גט שמקבלת תנאי בצורת ביטוי למבדא
    //ומטרתה לשלוף רשימת ישויות התואמת לתנאי
    IEnumerable<T> Get(Func<Group, bool> cond);
    T Get(int id);
}
