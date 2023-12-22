using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Labb2_DbWPF.Managers;
using Labb2_DbWPF.ViewModels;

namespace Labb2_DbWPF.Views
{

    /// <summary>
    /// Interaction logic for AddProductView.xaml
    /// </summary>
    public partial class AddProductView : UserControl, INotifyPropertyChanged
    {


        public AddProductView()
        {
            
            InitializeComponent();
            StoreComboBoxDisplay();
        }

        private async void StoreComboBoxDisplay()
        {

            

        }

        private void AddProduct_btn_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Requested function not done");
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
