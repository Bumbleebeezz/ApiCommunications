using System.Windows;
using Labb2_Db.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Labb2_DbWPF.Managers;

public class StoreInventoryManager
{
    private static readonly List<Book> books = new();

    public static event Action PropertyChanged;

    public static event Action ViewChanged;

    private static View _view;

    public static View CurrentView
    {
        get => _view;
        set
        {
            _view = value;
            ViewChanged.Invoke();
        }
    }

    public void AddBook(Book book,string ISBN,  int quantity)
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