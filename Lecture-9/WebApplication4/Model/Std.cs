using System;
using System.Collections.Generic;

namespace WebApplication4.Model;

public partial class Std
{
    public int Id { get; set; }

    public int Name { get; set; }

    public string Description { get; set; } = null!;
}
