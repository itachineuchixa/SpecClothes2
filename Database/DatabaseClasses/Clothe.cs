﻿using System;
using System.Collections.Generic;

namespace SpecClothes.Database.DatabaseClasses;

public partial class Clothe
{
    public long Idclothes { get; set; }

    public string Clothe1 { get; set; } = null!;

    public long Price { get; set; }

    public long Term { get; set; }

    public long VariableIdVariable { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; } = new List<Delivery>();

    public virtual Variable VariableIdVariableNavigation { get; set; } = null!;
}
