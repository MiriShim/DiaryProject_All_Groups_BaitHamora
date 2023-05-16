using Repository.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceAPI
{
    public  interface IStudentService
    {
        bool AddNew(DTO.StudentDTO  student);
    }
}
