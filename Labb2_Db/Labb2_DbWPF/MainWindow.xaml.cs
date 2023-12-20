using System.Windows;
using Labb2_DbWPF.Managers;

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