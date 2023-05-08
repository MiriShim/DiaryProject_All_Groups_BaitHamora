using DTO;
using Repository.DbModels;

namespace Services.ServiceAPI
{
    public interface IUnitService
    {
        List<UnitDTO> GetAll();
        void Save(UnitDTO unit);
    }
}