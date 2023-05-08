using DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.DbModels;
using Services.ServiceAPI;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService service;

        public UnitController(IUnitService _service )
        {
            service=_service;
         }
        // GET: api/<Unit>


        [HttpGet]
        public IEnumerable< UnitDTO> Get()
        {
            return service.GetAll();
        }

        // GET api/<Unit>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Unit>
        [HttpPost]
        public void Post([FromBody] DTO.UnitDTO unit)
        {
              service.Save(unit);

        }

        // PUT api/<Unit>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Unit>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
