using System;
using System.Collections.Generic;

namespace SpecClothes.Database.DatabaseClasses;

public partial class Department
{
    public long Iddepartment { get; set; }

    public string Department1 { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
