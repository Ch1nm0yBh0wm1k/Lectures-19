using System;
using System.Collections.Generic;

namespace WebApplication4.Model;

public partial class Course
{
    public int Id { get; set; }

    public int? Sid { get; set; }

    public string? Subject { get; set; }

    public string? InstructorName { get; set; }
}
