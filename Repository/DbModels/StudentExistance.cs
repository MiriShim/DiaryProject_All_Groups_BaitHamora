using System;
using System.Collections.Generic;

namespace Repository.DbModels;

public partial class StudentExistance
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int LessonId { get; set; }

    public int ExistanceType { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
