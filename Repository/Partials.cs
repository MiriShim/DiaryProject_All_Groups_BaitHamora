using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DbModels
{
    partial class Group
    {
        public override string ToString()
        {
            return $"{nameof (Id)}:{this.Id}, {nameof(GroupName )}:{GroupName}";
        }
    }
   
     partial class DiaryContext
    {
       
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().HasData(
                new School() {Id=-1, Name = "Seminar sharansky" }
                );
        }
    }
}
