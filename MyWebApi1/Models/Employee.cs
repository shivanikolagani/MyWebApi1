using System;
using System.Collections.Generic;

namespace MyWebApi1.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public int? DeptId { get; set; }

    public int? LibraryId { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual Library? Library { get; set; }
}
