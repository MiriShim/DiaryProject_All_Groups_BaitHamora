using Services.ServiceAPI;
using Services.ServicesImp;

namespace WebAPI
{
    public  class MyMappingProfile:AutoMapper.Profile 
    {
        public MyMappingProfile()
        {
            CreateMap<Repository.DbModels.Unit,DTO.UnitDTO>()
                //.ForMember(s=>s.ParentUnitId,a=>a.MapFrom(m=>m.ParentUnitId ))
                .ReverseMap();
             
        }
    }
}