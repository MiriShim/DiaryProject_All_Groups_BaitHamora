using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class GroupDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? SchoolId { get; set; }
         public string?  SchoolName { get; set; }
    }
}
