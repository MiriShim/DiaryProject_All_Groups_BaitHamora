using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.DbModels;

public partial class Lesson
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity )]
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int? GroupId { get; set; }

    public virtual Group? Group { get; set; }

    public virtual ICollection<StudentExistance> StudentExistances { get; set; } = new List<StudentExistance>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
