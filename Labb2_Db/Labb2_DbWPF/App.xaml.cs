using System.Reflection;
using System.Windows;
using Autofac;
using Labb2_Db.Entities;
using Labb2_DbWPF.Managers;
using Labb2_DbWPF.Services;
using Labb2_DbWPF.ViewModels;
using Microsoft.EntityFrameworkCore;
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

            services.AddDbContext<Labb1BookShopContext>(options => {
                options.UseSqlServer("Data Source=MARIACONFIG;Initial Catalog=Labb1_BookShop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"); 
            });

            services.AddSingleton<StoreInventoryManager>();

            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<AddProductViewModel>();
            services.AddSingleton<MoveInventoryViewModel>();
            services.AddSingleton<StoreInventoryViewModel>();
            services.AddSingleton<UpdateDeleteInventoryViewModel>();
            services.AddSingleton<INavigationService,NavigationService>();
            services.AddSingleton<IStoreService, StoreService>();
            
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
