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
using Labb2_DbWPF.Managers;
using static System.Net.Mime.MediaTypeNames;

namespace Labb2_DbWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static event Action BookListChanged;

        public MainWindow()
        {
            InitializeComponent();
            StoreInventoryManager.PropertyChanged += StoreInventoryManagerOnPropertyChanged;
            StoreInventoryManager.ViewChanged += StoreInventoryManagerOnViewChanged;
        }

        private void StoreInventoryManagerOnViewChanged()
        {
            if (StoreInventoryManager.CurrentView == null)
            {
                
            }
        }

        private void StoreInventoryManagerOnPropertyChanged()
        {
        }

        

        

        
    }
}