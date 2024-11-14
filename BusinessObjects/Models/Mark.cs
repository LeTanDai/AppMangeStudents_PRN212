using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Mark
{
    public string Semester { get; set; } = null!;

    public float? ProgressTest1 { get; set; }

    public float? ProgressTest2 { get; set; }

    public float? Lab1 { get; set; }

    public float? Lab2 { get; set; }

    public float? Assignment { get; set; }

    public float? PracticalExam { get; set; }

    public float? FinalExam { get; set; }

    public float? Total { get; set; }

    public string Idstudent { get; set; } = null!;

    public string Idsubject { get; set; } = null!;

    public string NameClass { get; set; } = null!;

    public string SchoolYear { get; set; } = null!;

    public virtual Subject IdsubjectNavigation { get; set; } = null!;

    public virtual StudentClass StudentClass { get; set; } = null!;
}
