using System.Windows;
using System.Windows.Controls;
using Labb2_Db.Entities;

namespace Labb2_DbWPF.Views
{
    /// <summary>
    /// Interaction logic for UpdateDeleteInventoryView.xaml
    /// </summary>
    public partial class UpdateDeleteInventoryView : UserControl
    {
        private Book? _selectedBook;

        public Book? SelectedBook
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
                    
                }
                else
                {
                    
                }
            }
        }
        public UpdateDeleteInventoryView()
        {
            InitializeComponent();
        }

        private void ScienceFictionBokhandelnUpdate_btn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreListViewDisplay(1);
        }

        private void AkademibokhandelnUpdate_btn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreListViewDisplay(2);
        }

        private void PocketShopUpdate_btn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreListViewDisplay(3);
        }

        private void BokusUpdate_btn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreListViewDisplay(4);
        }

        private void StoreListViewDisplay(int storeID)
        {
            UpdateStoreInventory_lv.Items.Clear();

            var db = new Labb1BookShopContext();

            var storeInventoryBalances = db.InventoryBalances.Where(s => s.StoreId == storeID).ToList();

            foreach (var book in storeInventoryBalances)
            {
                UpdateStoreInventory_lv.Items.Add(book);
            }
        }
    }
}
