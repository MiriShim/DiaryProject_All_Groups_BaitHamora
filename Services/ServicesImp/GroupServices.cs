using AutoMapper;
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
    public  class GroupServices:IGroupService
    {  
       // private readonly ICRUD<Group> _repository;
        private readonly IGroupDAL repository;
        private readonly IMapper _mapper;

        public GroupServices(IGroupDAL _repository,IMapper mapper)
        {
             repository = _repository;
            _mapper = mapper;
        }

        public IEnumerable <DTO. GroupDTO> GetAll ( )
        {
            // GroupDAL dal = new GroupDAL();

            var list =  repository.Get().ToList();
          //  var somedata = list.Select(g =>   g.Name );
           // var somedata2 = list.Select(g => new { g.Name, sum = g.Students.Count(), schoolname = g.School.Name ??"" } );
            return  list.Select(item=>_mapper.Map<DTO.GroupDTO>(item)); 
        }

    }
}
