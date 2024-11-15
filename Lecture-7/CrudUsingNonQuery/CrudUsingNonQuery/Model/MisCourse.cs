using System;
using System.Collections.Generic;

namespace CrudUsingNonQuery.Model;

public partial class MisCourse
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public string? CourseName { get; set; }

    public string? CourseDescription { get; set; }
}
