using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Rule
{
    public int MinAge { get; set; }

    public int MaxAge { get; set; }

    public double PassScore { get; set; }

    public int? TotalStudent { get; set; }
}
