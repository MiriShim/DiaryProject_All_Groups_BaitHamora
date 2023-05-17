using Microsoft.AspNetCore.Mvc;
using Repository.DbModels;
using Services.ServiceAPI;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Boker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly  IStudentService studentService;
        public StudentController(IStudentService _studentService)
        {
            studentService=_studentService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable< string > Get()
        {
            //Studentbl bl = new Studentbl();
            //return bl.getallstudent();

            return new string[] { "value1", "value2" };
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
           // studentService.AddNew(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
