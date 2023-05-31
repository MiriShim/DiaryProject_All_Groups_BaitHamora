using DTO;
using Repository.DbModels;
using Services.ServiceAPI;
using Services.ServicesImp;

namespace Services
{
    public class MyMappingProfile : AutoMapper.Profile
    {
        public MyMappingProfile()
        {
            CreateMap< Unit,  UnitDTO>()
                //.ForMember(s=>s.ParentUnitId,a=>a.MapFrom(m=>m.ParentUnitId ))
                .ReverseMap();

            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.EmailAddress, source => source.MapFrom(m => m.Email))
                .ForMember(d => d.GroupName, s => s.MapFrom(m => m.Group.GroupName))

               .ReverseMap()
               .ForMember(dest => dest.Email, source => source.MapFrom(m => m.EmailAddress))
                ;

        }
    }
}