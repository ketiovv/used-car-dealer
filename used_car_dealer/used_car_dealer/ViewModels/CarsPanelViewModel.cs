using Prism.Mvvm;
using System.Collections.ObjectModel;
using used_car_dealer.core;
using used_car_dealer.DAL.Entities;
using used_car_dealer.Models;

namespace used_car_dealer.ViewModels
{

    public class CarsPanelViewModel: BindableBase
    {
        private Model _model;

        private Car _selectedCar;
        public Car SelectedCar
        {
            get { return _selectedCar; }
            set { SetProperty(ref _selectedCar, value); }
        }

        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get { return _cars; }
            set { SetProperty(ref _cars, value); }
        }

        public CarsPanelViewModel(IApplicationCommands applicationCommands)
        {
            _model = new Model();
            _applicationCommands = applicationCommands;

            _cars = _model.Cars;
        }

        private IApplicationCommands _applicationCommands;

        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }
    }
}
