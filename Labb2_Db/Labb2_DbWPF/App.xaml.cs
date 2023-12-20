using System.Configuration;
using System.Data;
using System.Windows;
using Labb2_DbWPF.Services;
using Labb2_DbWPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Labb2_DbWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>()
            });
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<AddProductViewModel>();
            services.AddSingleton<MoveInventoryViewModel>();
            services.AddSingleton<StoreInventoryViewModel>();
            services.AddSingleton<UpdateDeleteInventoryViewModel>();
            services.AddSingleton<INavigationService,NavigationService>();

            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
