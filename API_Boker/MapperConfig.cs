using AutoMapper;
using DTO;
using Repository.DbModels;

namespace API_Boker
{
    public class MapperConfig :Profile 
    { 
            public MapperConfig()
            {
            // Add as many of these lines as you need to map your objects
            CreateMap<Group, GroupDTO>()
                //מיפוי לשם בית הספר מתוך טבלה קשורה לא חובה
                .ForMember(m => m.SchoolName, opt => opt.MapFrom(src => src.School.Name))

            .ReverseMap();
            CreateMap<Unit, UnitDTO>().ReverseMap();
        
        }
    }
}
