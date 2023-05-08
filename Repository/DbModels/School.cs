using System;
using System.Collections.Generic;

namespace Repository.DbModels;

public partial class School
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
