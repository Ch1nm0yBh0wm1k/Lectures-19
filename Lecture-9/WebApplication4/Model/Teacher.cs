using System;
using System.Collections.Generic;

namespace WebApplication4.Model;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;
}
