using Repository.DbModels;

namespace Services.ServiceAPI
{
    public interface ISchoolService
    {
        bool AddNew(School school);
        IEnumerable<School> GetAll();
    }
}