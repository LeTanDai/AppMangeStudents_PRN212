using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Assign
{
    public int AssignId { get; set; }

    public string Idteacher { get; set; } = null!;

    public string Idsubject { get; set; } = null!;

    public string NameClass { get; set; } = null!;

    public string SchoolYear { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;

    public virtual TeacherSubject TeacherSubject { get; set; } = null!;
}
