using AutoMapper;
using DTO;
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
        private readonly IGroupRepository   repository;
        private readonly IMapper _mapper;

        public GroupServices (IGroupRepository _repository,IMapper mapper)
        {
             repository = _repository;
            _mapper = mapper;
        }

        public void AddNew(GroupDTO value)
        {
             repository.AddNew(_mapper.Map<Group>(value));
        }

        public IEnumerable <DTO. GroupDTO> GetAll ( )
        {
            // GroupDAL dal = new GroupDAL();

            var list =   repository.Get().ToList();
          //  var somedata = list.Select(g =>   g.Name );
           // var somedata2 = list.Select(g => new { g.Name, sum = g.Students.Count(), schoolname = g.School.Name ??"" } );
            return  list.Select(item=>_mapper.Map<DTO.GroupDTO>(item)); 
        }

        public object GetWithSchoolName (int gId ) 
        {
            return  repository.GetDeatild(1);
        }
    }
}
