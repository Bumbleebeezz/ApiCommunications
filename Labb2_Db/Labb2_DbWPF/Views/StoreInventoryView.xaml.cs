using Labb2_Db.Entities;
using System.Windows;
using System.Windows.Controls;

namespace Labb2_DbWPF.Views
{
    public partial class StoreInventoryView : UserControl
    {
        public StoreInventoryView()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void ScienceFictionBokhandelnBtn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreListViewDisplay(1);
        }

        private void AkademibokhandelnBtn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreListViewDisplay(2);
        }

        private void PocketShopBtn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreListViewDisplay(3);
        }

        private void BokusBtn_OnClick(object sender, RoutedEventArgs e)
        {
            StoreListViewDisplay(4);
        }

        private void StoreListViewDisplay(int storeID)
        {
            StoreLv.Items.Clear();

            var db = new Labb1BookShopContext();

            var storeInventoryBalances = db.InventoryBalances.Where(s => s.StoreId == storeID).ToList();

            foreach (var book in storeInventoryBalances)
            {
                StoreLv.Items.Add(book);
            }
        }
    }
}
