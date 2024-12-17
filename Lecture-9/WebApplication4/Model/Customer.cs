using System;
using System.Collections.Generic;

namespace WebApplication4.Model;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Address { get; set; }
}
