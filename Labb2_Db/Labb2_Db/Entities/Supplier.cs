namespace Labb2_Db.Entities;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<StoreOrder> StoreOrders { get; set; } = new List<StoreOrder>();
}
