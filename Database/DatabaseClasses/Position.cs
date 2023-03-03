using System;
using System.Collections.Generic;

namespace SpecClothes.Database.DatabaseClasses;

public partial class Position
{
    public long Idposition { get; set; }

    public long Discount { get; set; }

    public string Posi { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
