using System.ComponentModel;
using System.Runtime.CompilerServices;
using Labb2_Db.Entities;
using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Labb2_DbWPF.Views
{
    /// <summary>
    /// Interaction logic for MoveInventoryView.xaml
    /// </summary>
    public partial class MoveInventoryView : UserControl, INotifyPropertyChanged
    {
        public MoveInventoryView()
        {
            InitializeComponent();
        }

        private Store _selectedProduct;

        public Store SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                if (_selectedProduct is null) return;
                _selectedProduct = value;
            }
        }

        private void ScienceFictionBokhandelnMoveFrom_btn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreListViewDisplay(1);
        }

        private void AkademibokhandelnMoveFrom_btn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreListViewDisplay(2);
        }

        private void PocketShopMoveFrom_btn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreListViewDisplay(3);
        }

        private void BokusMoveFrom_btn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreListViewDisplay(4);
        }

        private void StoreListViewDisplay(int storeID)
        {
            MoveInventory_lv.Items.Clear();

            var db = new Labb1BookShopContext();

            var storeInventoryBalances = db.InventoryBalances.Where(s => s.StoreId == storeID).ToList();

            foreach (var book in storeInventoryBalances)
            {
                MoveInventory_lv.Items.Add(book);
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
