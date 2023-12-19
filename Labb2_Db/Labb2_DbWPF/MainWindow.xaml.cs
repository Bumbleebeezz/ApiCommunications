using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Labb2_Db.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace Labb2_DbWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static event Action ProductListChanged;

        public MainWindow()
        {
            InitializeComponent();
        }

        private InventoryBalance? _selectedBook;

        public InventoryBalance? SelectedBook
        {
            get
            {
                return _selectedBook;
            }
            set
            {
                if (_selectedBook == value) return;
                _selectedBook = value;
                if (value is null)
                {
                    BookTitleTextBox.Text = string.Empty;
                    BookPriceTextBox.Text = string.Empty;
                    BookQuantityTextBox.Text = string.Empty;
                }
                else
                {
                    BookTitleTextBox.Text = _selectedBook.Title;
                    BookPriceTextBox.Text = _selectedBook.UnitPrice.ToString();
                    BookQuantityTextBox.Text = _selectedBook.Quantity.ToString();
                }
            }
        }

        private void ScienceFictionBokhandelnBtn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreLv.Items.Clear();

            var db = new Labb1BookShopContext();

            var storeInventoryBalances = db.InventoryBalances.Where(s => s.StoreId == 1).ToList();

            foreach (var book in storeInventoryBalances)
            {
                StoreLv.Items.Add(book);
            }
        }

        private void AkademibokhandelnBtn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreLv.Items.Clear();

            var db = new Labb1BookShopContext();

            var storeInventoryBalances = db.InventoryBalances.Where(s => s.StoreId == 2).ToList();

            foreach (var book in storeInventoryBalances)
            {
                StoreLv.Items.Add(book);
            }
        }

        private void PocketShopBtn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreLv.Items.Clear();

            var db = new Labb1BookShopContext();

            var storeInventoryBalances = db.InventoryBalances.Where(s => s.StoreId == 3).ToList();

            foreach (var book in storeInventoryBalances)
            {
                StoreLv.Items.Add(book);
            }
        }

        private void BokusBtn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreLv.Items.Clear();

            var db = new Labb1BookShopContext();

            var storeInventoryBalances = db.InventoryBalances.Where(s => s.StoreId == 4).ToList();

            foreach (var book in storeInventoryBalances)
            {
                StoreLv.Items.Add(book);
            }
        }

        private void UpdateBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}