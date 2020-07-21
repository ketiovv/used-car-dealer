using Prism.Mvvm;
using Prism.Regions;
using used_car_dealer.Views;

namespace used_car_dealer.ViewModels
{
    public class MainWindowViewModel: BindableBase
    {
        IRegionManager _regionManager;
        private string _title = "User car dealer";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion(used_car_dealer.core.RegionNames.ContentRegion, typeof(MainMenu));
        }
    }
}
