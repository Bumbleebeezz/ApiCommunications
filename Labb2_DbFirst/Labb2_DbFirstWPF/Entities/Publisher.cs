using System;
using System.Collections.Generic;

namespace Labb2_DbFirstWPF.Entities;

public partial class Publisher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<StoreOrder> StoreOrders { get; set; } = new List<StoreOrder>();
}
