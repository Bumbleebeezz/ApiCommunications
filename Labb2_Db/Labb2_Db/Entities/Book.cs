using System;
using System.Collections.Generic;

namespace Labb2_Db.Entities;

public partial class Book
{
    public string Isbn { get; set; } = null!;

    public int FormatId { get; set; }

    public string Title { get; set; } = null!;

    public int AuthorId { get; set; }

    public string Language { get; set; } = null!;

    public int GenreId { get; set; }

    public int Pages { get; set; }

    public double Price { get; set; }

    public DateOnly Release { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Format Format { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;

    public virtual ICollection<InventoryBalance> InventoryBalances { get; set; } = new List<InventoryBalance>();

    public virtual ICollection<StoreOrder> StoreOrders { get; set; } = new List<StoreOrder>();
}
