using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.DbModels;

public partial class Group
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? SchoolId { get; set; }

    //lazy loading
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual School? School { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
