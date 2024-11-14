using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Teacher
{
    public string Idteacher { get; set; } = null!;

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateOnly? BirthDay { get; set; }

    public string? PassWord { get; set; }

    public string? IsActive { get; set; }

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
