using Microsoft.AspNetCore.Mvc;
using Repository.DbModels;
using Repository.Imp;
using Services.ServiceAPI;
using Services.ServicesImp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Boker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService service;

        public SchoolController(ISchoolService _service)
        {
            this.service = _service;
        }

        // GET: api/<SchoolController>
        [HttpGet]
        public IEnumerable<School> Get()
        {//הנה פתרון אבל לא הרווחתי כלום רק העברתי את התלות למקום אחר
            //return new Services.ServicesImp.SchoolService(new SchoolRepository()).GetAll();
            //return new SchoolService(new SchoolRepository()).GetAll();
            return service.GetAll();
        }

        // GET api/<SchoolController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SchoolController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SchoolController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SchoolController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
