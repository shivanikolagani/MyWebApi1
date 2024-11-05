using System;
using System.Collections.Generic;

namespace MyWebApi1.Models;

public partial class Library
{
    public int LibraryId { get; set; }

    public string? LibraryName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
