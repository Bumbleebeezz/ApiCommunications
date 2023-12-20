using System.Windows.Input;
using System.Windows.Media.Converters;
using Labb2_DbWPF.Services;

namespace Labb2_DbWPF.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private INavigationService _navigation;

    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand NavigateToHomeCommand { get; set; }
    public RelayCommand NavigateToAddProductCommand { get; set; }
    public RelayCommand NavigateToMoveInventoryCommand { get; set; }
    public RelayCommand NavigateToStoreInventoryCommand { get; set; }
    public RelayCommand NavigateToUpdateDeleteInventoryCommand { get; set; }

    public MainWindowViewModel(INavigationService navService)
    {
        Navigation = navService;
        NavigateToHomeCommand = new RelayCommand(execute:o => {Navigation.NavigateTo<MainWindowViewModel>();}, canExecute: o => true);
        NavigateToAddProductCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<AddProductViewModel>(); }, canExecute: o => true);
        NavigateToMoveInventoryCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<MoveInventoryViewModel>(); }, canExecute: o => true);
        NavigateToStoreInventoryCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<StoreInventoryViewModel>(); }, canExecute: o => true);
        NavigateToUpdateDeleteInventoryCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<UpdateDeleteInventoryViewModel>(); }, canExecute: o => true);

    }

}