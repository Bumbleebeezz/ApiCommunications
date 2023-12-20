using Labb2_DbWPF.ViewModels;

namespace Labb2_DbWPF.Services;

public interface INavigationService
{
    ViewModel CurrentView { get; }

    void NavigateTo<View>() where View : ViewModel;
}