using Prism.Mvvm;
using System.Collections.ObjectModel;
using used_car_dealer.core;
using used_car_dealer.DAL.Entities;
using used_car_dealer.Models;

namespace used_car_dealer.ViewModels
{
    class CustomersPanelViewModel: BindableBase
    {
        private Model _model;

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { SetProperty(ref _customers, value); }
        }


        public CustomersPanelViewModel(IApplicationCommands applicationCommands)
        {
            _model = new Model();
            _applicationCommands = applicationCommands;

            _customers = _model.Customers;
        }


        private IApplicationCommands _applicationCommands;
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }
    }
}
