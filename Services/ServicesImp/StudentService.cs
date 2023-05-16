using AutoMapper;
using DTO;
using Repository.DbModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesImp
{
    public class StudentService : ServiceAPI.IStudentService
    {
        private readonly IStudentRepository repository;
        private readonly IMapper mapper;
        public StudentService(IStudentRepository _repository,IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }
        public bool AddNew(StudentDTO student)
        {
            //משתמשים באוביקט המיפוי כדי להמיר את האוביקט DTO לאוביקט entity
            Student studentEntity = mapper.Map<Student >(student);
            return repository.AddNew(studentEntity);
        }
 
    }
}
