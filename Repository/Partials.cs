using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DbModels
{
    public partial  class Group
    {
        public override string ToString()
        {
            return $"{nameof (Id)}:{this.Id}, {nameof(Name)}:{Name }";
        }
    }
    public partial class DiaryContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

        }
    }
}
