using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DbModels;

//[Table("Kitot")]
public partial class Group
{
    [Key]
  //[DatabaseGenerated(DatabaseGeneratedOption.None ) ]
    public int Id { get; set; }
  
    [MinLength(2) ]
    [MaxLength(30) ]
    //[DataType("nvarchar(30)")]
    public string? GroupName { get; set; }

    public int? SchoolId { get; set; }
    
    //lazy loading
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual School? School { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
