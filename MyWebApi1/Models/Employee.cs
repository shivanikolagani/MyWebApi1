using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyWebApi1.Models;

public partial class Employee
{
    [DisplayName("Employee Id")]
    public int EmpId { get; set; }

    [DisplayName("EmployeeName")]
    public string? EmpName { get; set; }

    public int? DeptId { get; set; }

    public int? LibraryId { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual Library? Library { get; set; }
}
