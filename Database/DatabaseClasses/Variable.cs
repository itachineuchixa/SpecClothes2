using System;
using System.Collections.Generic;

namespace SpecClothes.Database.DatabaseClasses;

public partial class Variable
{
    public long IdVariable { get; set; }

    public string Variable1 { get; set; } = null!;

    public virtual ICollection<Clothe> Clothes { get; } = new List<Clothe>();
}
