using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceAPI
{
    public  interface IGroupService
    {
        void AddNew(GroupDTO value);
        IEnumerable<DTO.GroupDTO> GetAll();
        object GetWithSchoolName(int gId);
    }
}
