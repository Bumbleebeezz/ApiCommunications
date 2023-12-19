using System.Windows;
using Labb2_Db.Entities;

namespace Labb2_DbWPF.Managers;

public class StoreInventoryManager
{
    private static readonly List<Book> books = new();

    public static event Action PropertyChanged;

    public void AddBook(Book book, int quantity)
    {
        var bookFound = books.FirstOrDefault(b => b.Isbn == book.Isbn);
        if (bookFound is not null)
        {
            MessageBox.Show("Book already excists!!");
        }
        else
        {
            var newBook = new Book();
        }
    }

    public static async Task LoadStoresInventory()
    {

    }
}