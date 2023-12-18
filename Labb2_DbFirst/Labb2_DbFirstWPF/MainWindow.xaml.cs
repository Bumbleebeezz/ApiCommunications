using System;
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
using Labb2_DbFirst.Entities;

namespace Labb2_DbFirstWPF
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SciFiBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var db = new Labb1BookShopContext();

            var storeInventory = db.InventoryBalances
                .ToList()
                .Where(s => s.StoreId == 1);

            foreach (var book in storeInventory)
            {
                StoreLv.Items.Add(book);
            }
        }

        private void AkademiBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PocketShopBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BokusBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}