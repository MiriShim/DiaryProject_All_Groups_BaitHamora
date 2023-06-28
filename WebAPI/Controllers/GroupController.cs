
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


using System.Diagnostics;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;

        private readonly IGroupService _groupService;

        public GroupController(IGroupService service, ILogger<GroupController> logger)
        {
            _logger = logger;
            _groupService = service;
        }




        // GET: api/<GroupController>
        [HttpGet]
        public IEnumerable<GroupDTO> Get()
        {
            _logger.LogInformation($" ברוכה הבאה GroupController Get executed at : {DateTime.Now.ToShortTimeString()}");


            return _groupService.GetAll();
        }
        // GET api/<GroupController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //EventLog logger = new("Application" );
            //logger.Source = "Application";
            //logger.WriteEntry($"group controller get method executed at {DateTime.Now.ToShortTimeString() }",EventLogEntryType.Warning   );

            return "תגובה מהשירות שיצרנו";
        }

        // POST api/<GroupController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
