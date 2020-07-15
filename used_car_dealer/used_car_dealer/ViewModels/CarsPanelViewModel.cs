using Prism.Mvvm;
using used_car_dealer.core;

namespace used_car_dealer.ViewModels
{

    public class CarsPanelViewModel: BindableBase
    {
        private IApplicationCommands _applicationCommands;

        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }

        public CarsPanelViewModel(IApplicationCommands applicationCommands)
        {
            _applicationCommands = applicationCommands;
        }
    }
}
