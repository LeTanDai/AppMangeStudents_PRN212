using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class StudentClass
{
    public string Idstudent { get; set; } = null!;

    public string NameClass { get; set; } = null!;

    public string SchoolYear { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;

    public virtual Student IdstudentNavigation { get; set; } = null!;

    public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();
}
