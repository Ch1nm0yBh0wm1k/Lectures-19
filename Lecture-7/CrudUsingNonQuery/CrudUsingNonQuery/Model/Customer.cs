using System;
using System.Collections.Generic;

namespace CrudUsingNonQuery.Model;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }
}
