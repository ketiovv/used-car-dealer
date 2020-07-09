using used_car_dealer.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

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

        }
    }
}
