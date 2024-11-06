using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyWebApi1.Models;

public partial class Department
{
    //[DisplayName("Department Id")]
    public int DeptId { get; set; }

    [DisplayName("DepartmentName")]
    public string? DeptName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
