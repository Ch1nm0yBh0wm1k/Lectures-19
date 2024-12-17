using System;
using System.Collections.Generic;

namespace WebApplication4.Model;

public partial class Emp
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Address { get; set; } = null!;
}
