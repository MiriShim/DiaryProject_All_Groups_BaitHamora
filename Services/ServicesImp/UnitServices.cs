using AutoMapper;
using DTO;
using Repository.DbModels;
using Repository.Imp;
using Services.ServiceAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;

namespace Services.ServicesImp
{
    public   class UnitServices:IUnitService
    {
       private readonly IMapper mapper;
        private readonly ICRUD<Unit > unitDal;
        public UnitServices(IMapper m,ICRUD<Unit  > unitDal)
        {
            this.unitDal = unitDal;
            mapper = m;
        }
        public List<DTO. UnitDTO>  GetAll()
        {
             return unitDal.Get ().Select(m=>mapper.Map<DTO.UnitDTO>(m)).ToList();
        }

        public void Save(UnitDTO unit)
        {
              unitDal .AddNew (mapper.Map<Unit>( unit));
        }
    }
}
