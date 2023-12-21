using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Labb2_Db.Entities;

namespace Labb2_DbWPF.Views
{
    /// <summary>
    /// Interaction logic for UpdateDeleteInventoryView.xaml
    /// </summary>
    public partial class UpdateDeleteInventoryView : UserControl, INotifyPropertyChanged
    {
        
        public UpdateDeleteInventoryView()
        {
            InitializeComponent();
            DataContext = this;
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
                    BookTitleUpdate_tb.Text = string.Empty;
                    BookPriceUpdate_tb.Text = string.Empty;
                    BookQuantityUpdate_tb.Text = string.Empty;
                    InventoryValueUpdate_tb.Text = string.Empty;
                }
                else
                {
                    BookTitleUpdate_tb.Text = _selectedBook.Title;
                    BookPriceUpdate_tb.Text = _selectedBook.UnitPrice.ToString();
                    BookQuantityUpdate_tb.Text = _selectedBook.Quantity.ToString();
                    InventoryValueUpdate_tb.Text = _selectedBook.TotalValue.ToString();
                }
            }
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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
