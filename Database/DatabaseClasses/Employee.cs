using System;
using System.Collections.Generic;

namespace SpecClothes.Database.DatabaseClasses;

public partial class Employee
{
    public long IdEmployees { get; set; }

    public string Fio { get; set; } = null!;

    public long DepartmentsIddepartment { get; set; }

    public long PositionIdposition { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; } = new List<Delivery>();

    public virtual Department DepartmentsIddepartmentNavigation { get; set; } = null!;

    public virtual Position PositionIdpositionNavigation { get; set; } = null!;
}
