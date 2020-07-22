using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using used_car_dealer.core;

namespace used_car_dealer.ViewModels
{
    public class MainMenuViewModel: BindableBase
    {
        private readonly IRegionManager _regionManager;

        public MainMenuViewModel(IRegionManager regionManager, IApplicationCommands applicationCommands)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
            applicationCommands.NavigateCommand.RegisterCommand(NavigateCommand);
        }
        public DelegateCommand<string> NavigateCommand { get; private set; }


        private void Navigate(string navigationPath)
        {
            if (navigationPath != null)
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
            }
        }
    }
}
