using System;
using System.Collections.Generic;

namespace CrudUsingNonQuery.Model;

public partial class MisStudent
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Address { get; set; }
}
