﻿using Microsoft.AspNetCore.Mvc;
using Services.ServiceAPI;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Boker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
       private readonly  IGroupService  _groupService;

        public GroupController(IGroupService service)
        {
            _groupService = service;
        }

        // GET: api/<GroupController>
        [HttpGet]
        public IEnumerable<DTO.GroupDTO> Get()
        {
            
            return _groupService.GetAll();   
        }

        // GET api/<GroupController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
