using AutoMapper;
using DTO;
using Repository.DbModels;
using Repository.Interfaces;
using Services.ServiceAPI;


namespace Services.ServicesImp
{
    public class StudentService : IStudentService
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

        public List<StudentDTO> GetAll()
        {
           // var listModels= repository.Get();
            return repository.Get().Select(s=>mapper.Map<StudentDTO >(s)).ToList() ;

            //List<StudentDTO> list = new List<StudentDTO>(); 
            //foreach (var item in listModels)
            //{
            //    list.Add(mapper.Map<StudentDTO >(item));
            //}
            //return list;    
        }

        public void Update(StudentDTO student)
        {
            throw new NotImplementedException();
        }
    }
}
