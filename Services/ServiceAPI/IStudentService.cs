using DTO;
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
        bool AddNew(StudentDTO  student);

        List<StudentDTO> GetAll();

        void Update(StudentDTO student );
    }
}
