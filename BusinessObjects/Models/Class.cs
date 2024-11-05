using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Class
{
    public string NameClass { get; set; } = null!;

    public string SchoolYear { get; set; } = null!;

    public virtual ICollection<Assign> Assigns { get; set; } = new List<Assign>();

    public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();
}
