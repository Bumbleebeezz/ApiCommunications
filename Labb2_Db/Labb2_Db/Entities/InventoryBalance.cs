using System;
using System.Collections.Generic;

namespace Labb2_Db.Entities;

public partial class InventoryBalance
{
    public int StoreId { get; set; }

    public string Isbn { get; set; } = null!;

    public int AuthorId { get; set; }

    public int FormatId { get; set; }

    public int? Quantity { get; set; }

    public string? Title { get; set; }

    public double? UnitPrice { get; set; }

    public double? TotalValue { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Format Format { get; set; } = null!;

    public virtual Book IsbnNavigation { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
