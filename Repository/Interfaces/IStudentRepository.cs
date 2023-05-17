using Repository.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public  interface IStudentRepository: Interfaces.ICRUD<Student >
    {
        IEnumerable<Student> GetStudentsIncludeGroup();    
    }
}
