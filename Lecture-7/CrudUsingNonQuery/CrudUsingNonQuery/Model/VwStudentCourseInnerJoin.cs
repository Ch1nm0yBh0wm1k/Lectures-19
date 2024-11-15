using System;
using System.Collections.Generic;

namespace CrudUsingNonQuery.Model;

public partial class VwStudentCourseInnerJoin
{
    public string? Name { get; set; }

    public string? Address { get; set; }

    public int Cid { get; set; }

    public string? CourseName { get; set; }

    public string? CourseDescription { get; set; }
}
