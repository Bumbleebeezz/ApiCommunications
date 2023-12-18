
using Labb2_Db.Entities;

Console.WriteLine("Hello, World!");

var db = new Labb1BookShopContext();

var storeInventoryBalances = db.InventoryBalances.Where(s=>s.StoreId == 1).ToList();

foreach (var book in storeInventoryBalances)
{
    Console.WriteLine($"{book.StoreId}, {book.Title}, {book.UnitPrice}, {book.Quantity}");
}
Console.ReadKey();