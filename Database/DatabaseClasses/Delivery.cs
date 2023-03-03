using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecClothes.Database.DatabaseClasses;

public partial class Delivery
{
    public long Iddelivery { get; set; }

    public string Datato { get; set; } = null!;

    public string Datatrade { get; set; } = null!;

    public long Price { get; set; }

    public long ClothesIdclothes { get; set; }

    public long EmployeesIdEmployees { get; set; }
    public virtual Clothe ClothesIdclothesNavigation { get; set; } = null!;

    public virtual Employee EmployeesIdEmployeesNavigation { get; set; } = null!;
}
