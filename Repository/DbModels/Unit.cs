using System;
using System.Collections.Generic;

namespace Repository.DbModels;

public partial class Unit
{
    public int Id { get; set; }

    public string? UnitName { get; set; }

    public string? Comments { get; set; }

    public int? ParentUnitId { get; set; }

    public int? EstimatedHours { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
