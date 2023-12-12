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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SciFiBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var db = new Labb1BookShopContext();

            var books = db.Books
                .ToList()
                .OrderBy(b => b.Price);

            foreach (var book in books)
            {
                LeftTb.Text += book.Title;
                LeftTb.Text += "\n";
            }
        }
    }
}