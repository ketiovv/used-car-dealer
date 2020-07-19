using Prism.Mvvm;
using System.Collections.ObjectModel;
using used_car_dealer.core;
using used_car_dealer.DAL.Entities;
using used_car_dealer.Models;

namespace used_car_dealer.ViewModels
{
    public class DealsPanelViewModel: BindableBase
    {
        private Model _model;

        private Deal _selectedDeal;
        public Deal SelectedDeal
        {
            get { return _selectedDeal; }
            set { SetProperty(ref _selectedDeal, value); }
        }

        private ObservableCollection<Deal> _deals;
        public ObservableCollection<Deal> Deals
        {
            get { return _deals; }
            set { SetProperty(ref _deals, value); }
        }

        public DealsPanelViewModel(IApplicationCommands applicationCommands)
        {
            _model = new Model();
            _applicationCommands = applicationCommands;

            _deals = _model.Deals;
        }

        private IApplicationCommands _applicationCommands;

        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }


    }
}
