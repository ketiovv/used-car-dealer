using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
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
            get => _selectedCar;
            set => SetProperty(ref _selectedCar, value);
        }


        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set => SetProperty(ref _cars, value);
        }

        //manufacturer

        // model

        private int _price = 20000;
        public int Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }


        private CarType _type = CarType.hatchback;
        public CarType Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }


        private string _color = "black";
        public string Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }


        private int _mileage;
        public int Mileage
        {
            get => _mileage;
            set => SetProperty(ref _mileage, value);
        }


        private int _yearFrom;
        public int YearFrom
        {
            get => _yearFrom;
            set => SetProperty(ref _yearFrom, value);
        }


        private int _engineCapacity;
        public int EngineCapacity
        {
            get => _engineCapacity;
            set => SetProperty(ref _engineCapacity, value);
        }


        private CarFuel _fuel;
        public CarFuel Fuel
        {
            get => _fuel;
            set => SetProperty(ref _fuel, value);
        }


        private int _power;
        public int Power
        {
            get => _power;
            set => SetProperty(ref _power, value);
        }


        private CarTransmission _transmission;
        public CarTransmission Transmission
        {
            get => _transmission;
            set => SetProperty(ref _transmission, value);
        }



        public CarsPanelViewModel(IApplicationCommands applicationCommands)
        {
            _model = new Model();
            _applicationCommands = applicationCommands;

            _cars = _model.Cars;

            _addCarCommand = new DelegateCommand(AddCar, AddCustomerPossible);
            _editCarCommand = new DelegateCommand(EditCar, EditCustomerPossible);
            _deleteCarCommand = new DelegateCommand(DeleteCar, DeleteCustomerPossible);
        }

        private IApplicationCommands _applicationCommands;

        public IApplicationCommands ApplicationCommands
        {
            get => _applicationCommands;
            set => SetProperty(ref _applicationCommands, value);
        }

        private ICommand _addCarCommand;
        public ICommand AddCarCommand
        {
            get => _addCarCommand;
            set => SetProperty(ref _addCarCommand, value);
        }
        private ICommand _editCarCommand;
        public ICommand EditCarCommand
        {
            get => _editCarCommand;
            set => SetProperty(ref _editCarCommand, value);
        }
        private ICommand _deleteCarCommand;
        public ICommand DeleteCarCommand
        {
            get => _deleteCarCommand;
            set => SetProperty(ref _deleteCarCommand, value);
        }

        public void AddCar()
        {
            //var car = new Car();
            if (_model.AddCustomerToDatabase(car))
            {
                ClearForm();
                MessageBox.Show("new customer in database!");
            }
        }

        public void EditCar()
        {
            MessageBox.Show("Not implemented");
        }
        public void DeleteCar()
        {
            //var car = SelectedCustomer;
            if (_model.DeleteCustomerFromDatabase(car))
            {
                MessageBox.Show($"customer with id:{car.Id} deleted from database!");
            }
        }

        public bool AddCustomerPossible()
        {
            return true;
        }

        public bool EditCustomerPossible()
        {
            return false;
        }
        public bool DeleteCustomerPossible()
        {
            return true;
        }

        public void ClearForm()
        {
            Name = string.Empty; LastName = string.Empty; Pesel = string.Empty;
            PhoneNumber = string.Empty; PostalCode = string.Empty; City = string.Empty;
            Street = string.Empty; HomeNumber = 0; BirthDate = string.Empty;
        }
    }
}
