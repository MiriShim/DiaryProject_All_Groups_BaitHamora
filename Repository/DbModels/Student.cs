using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DbModels;

//[Table ("students")]
public partial class Student:User
{
   // public int Id { get; set; }
    public int GroupId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<StudentExistance> StudentExistances { get; set; } = new List<StudentExistance>();
}
