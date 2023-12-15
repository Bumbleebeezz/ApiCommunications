using System;
using System.Collections.Generic;

namespace Labb2_DbFirstWPF.Entities;

public partial class StoreOrder
{
    public int Id { get; set; }

    public int StoreId { get; set; }

    public int SupplierId { get; set; }

    public int PublisherId { get; set; }

    public string Isbn { get; set; } = null!;

    public int FormatId { get; set; }

    public int? Quantity { get; set; }

    public virtual Format Format { get; set; } = null!;

    public virtual Book IsbnNavigation { get; set; } = null!;

    public virtual Publisher Publisher { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
