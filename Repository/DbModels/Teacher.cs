using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DbModels
{
    public  class Teacher : User
    {
        public string Specialization { get; set; }
    }
}
