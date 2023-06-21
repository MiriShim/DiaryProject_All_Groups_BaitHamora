using Microsoft.AspNetCore.Mvc;
using Repository.DbModels;
using Services.ServiceAPI;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

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
            EventLog eventLog = new EventLog("Application");
            eventLog.Source = "Application";
            eventLog.WriteEntry($"StudentController new instance at {DateTime.Now.ToShortTimeString}", EventLogEntryType.SuccessAudit );

            studentService = _studentService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable< DTO.StudentDTO  > Get()
        {
            //Studentbl bl = new Studentbl();
            //return bl.getallstudent();

            return studentService.GetAll();
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
