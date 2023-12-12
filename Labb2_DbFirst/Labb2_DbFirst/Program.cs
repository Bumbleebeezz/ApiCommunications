
using Labb2_DbFirst.Entities;

Console.WriteLine("Hello, Database!\n=========================================\n");

var db = new Labb1BookShopContext();


var books = db.Books
    .ToList()
    .OrderBy(b=>b.Price);

foreach (var book in books)
{
    Console.WriteLine($"Title: {book.Title} \nPrice: {book.Price} kr \n");
}

Console.WriteLine("\n=====================================\n");

var bookNotFound = db.Books
    .ToList()
    .Where(b => b.Title == "Error");

if (bookNotFound == null)
{
    Console.WriteLine("Error: Book not found");
}
else
{
    Console.WriteLine("How did this happend???");
}


