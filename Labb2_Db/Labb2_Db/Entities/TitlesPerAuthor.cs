using System;
using System.Collections.Generic;

namespace Labb2_Db.Entities;

public partial class TitlesPerAuthor
{
    public string? Name { get; set; }

    public int? Age { get; set; }

    public int? Titles { get; set; }

    public string InventoryValue { get; set; } = null!;
}
