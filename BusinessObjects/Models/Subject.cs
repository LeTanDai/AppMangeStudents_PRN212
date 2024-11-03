using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Subject
{
    public string Idsubject { get; set; } = null!;

    public string? NameSubject { get; set; }

    public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
