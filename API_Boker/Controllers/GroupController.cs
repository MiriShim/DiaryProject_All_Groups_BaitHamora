using DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.DbModels;
using Services.ServiceAPI;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Boker.Controllers
{
    [Route("api123/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
       private readonly  ILogger<GroupController> _logger;
       private readonly  IGroupService  _groupService;

        public GroupController(IGroupService service,ILogger<GroupController > logger)
        {
            _logger = logger;
            _groupService = service;
        }

        // GET: api/<GroupController>
        [HttpGet]
        public IEnumerable<DTO.GroupDTO> Get()
        {
            _logger.LogInformation($"GroupController Get executed at : {DateTime.Now.ToShortTimeString()  }");
            return _groupService.GetAll();   
        }

        [HttpGet("Somthing/{num}")]
        public  string   Somthing(int num)
        {
             
            return $"Somthing {num}";

        }


        [HttpGet("GetWithSchool {id}")]
         
        public object GetWithSchool(int id)
        {
            _logger.LogInformation("GetWithSchool");
            return _groupService.GetWithSchoolName(id);
        }

        //// GET api/<GroupController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<GroupController>
        [HttpPost]
        public void Post([FromBody] GroupDTO value)
        {
            _groupService.AddNew(value );
        }

        // PUT api/<GroupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GroupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
