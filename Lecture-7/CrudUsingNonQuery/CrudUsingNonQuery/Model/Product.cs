using System;
using System.Collections.Generic;

namespace CrudUsingNonQuery.Model;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }
}
