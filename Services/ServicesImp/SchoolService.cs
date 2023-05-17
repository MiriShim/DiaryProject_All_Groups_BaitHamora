using Repository.DbModels;
using Repository.Imp;
using Repository.Interfaces;
using Services.ServiceAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesImp
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository repository;
        public SchoolService(ISchoolRepository _repository)
        {
            this.repository = _repository;
        }

        public bool AddNew(School school)
        {
            // SchoolRepository sr = new();
            return repository.AddNew(school);
        }

        public IEnumerable<School> GetAll()
        {
            return repository.Get();
        }
    }
}
