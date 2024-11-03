using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class TeacherSubject
{
    public string Idteacher { get; set; } = null!;

    public string Idsubject { get; set; } = null!;

    public virtual Subject IdsubjectNavigation { get; set; } = null!;

    public virtual Teacher IdteacherNavigation { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
