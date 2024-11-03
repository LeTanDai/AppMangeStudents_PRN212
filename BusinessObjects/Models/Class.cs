using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Class
{
    public string NameClass { get; set; } = null!;

    public string SchoolYear { get; set; } = null!;

    public string? Idteacher { get; set; }

    public virtual Teacher? IdteacherNavigation { get; set; }

    public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
