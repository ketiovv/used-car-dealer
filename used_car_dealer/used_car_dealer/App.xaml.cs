using used_car_dealer.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Prism.Mvvm;
using used_car_dealer.ViewModels;
using used_car_dealer.core;

namespace used_car_dealer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainMenu>("MainMenu");
            containerRegistry.RegisterForNavigation<CarsPanel>("CarsPanel");
            containerRegistry.RegisterForNavigation<CustomersPanel>("CustomersPanel");
            containerRegistry.RegisterForNavigation<DealsPanel>("DealsPanel");

            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
        }

    }
}
