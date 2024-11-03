using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Admin
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateOnly? BirthDay { get; set; }

    public string? PassWord { get; set; }
}
