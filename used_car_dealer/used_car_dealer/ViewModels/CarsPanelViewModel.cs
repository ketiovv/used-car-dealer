using System;
using System.Collections.Generic;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
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

        #region Properties

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


        private CarManufacturer _selectedManufacturer;
        public CarManufacturer SelectedManufacturer
        {
            get => _selectedManufacturer;
            set => SetProperty(ref _selectedManufacturer, value, RefreshModels);
        }


        private ObservableCollection<CarManufacturer> _manufacturers;
        public ObservableCollection<CarManufacturer> Manufacturers
        {
            get => _manufacturers;
            set => SetProperty(ref _manufacturers, value);
        }


        private CarModel _selectedModel;
        public CarModel SelectedModel
        {
            get => _selectedModel;
            set => SetProperty(ref (_selectedModel), value);
        }


        private ObservableCollection<CarModel> _models = new ObservableCollection<CarModel>();
        public ObservableCollection<CarModel> Models
        {
            get => _models;
            set => SetProperty(ref _models, value);
        }


        private uint _price;
        public uint Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }


        private CarType _type;
        public CarType Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }


        private string _color;
        public string Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }


        private uint _mileage;
        public uint Mileage
        {
            get => _mileage;
            set => SetProperty(ref _mileage, value);
        }


        private uint _yearFrom;
        public uint YearFrom
        {
            get => _yearFrom;
            set => SetProperty(ref _yearFrom, value);
        }


        private uint _engineCapacity;
        public uint EngineCapacity
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


        private uint _power;
        public uint Power
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

        #endregion

        #region Ctor

        public CarsPanelViewModel(IApplicationCommands applicationCommands)
        {
            _model = new Model();
            _applicationCommands = applicationCommands;

            _cars = _model.Cars;

            _manufacturers = _model.CarManufacturers;

            _addCarCommand = new DelegateCommand(AddCar, AddCarPossible);
            _editCarCommand = new DelegateCommand(EditCar, EditCarPossible);
            _deleteCarCommand = new DelegateCommand(DeleteCar, DeleteCarPossible);
        }

        #endregion

        #region Commands

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

        #endregion

        #region Methods

        public void AddCar()
        {
            var car = new Car(Convert.ToUInt32(SelectedModel.Id), Price, Type, Color,
                Mileage, YearFrom, EngineCapacity, Fuel, Power, Transmission);
            if (_model.AddCarToDatabase(car))
            {
                ClearForm();
                MessageBox.Show("new car in database!");
            }
        }

        public void EditCar()
        {

        }
        public void DeleteCar()
        {
            var car = SelectedCar;
            if (_model.DeleteCarFromDatabase(car))
            {
                MessageBox.Show($"customer with id:{car.Id} deleted from database!");
            }
        }

        public bool AddCarPossible() => true;

        public bool EditCarPossible() => false;

        public bool DeleteCarPossible() => true;

        public void ClearForm()
        {
            SelectedManufacturer = Manufacturers.First(); SelectedModel = null; Price = 0; Type = CarType.coupe; Color = string.Empty; Mileage = 0;
            YearFrom = 0; EngineCapacity = 0; Fuel = CarFuel.diesel; Power = 0; Transmission = CarTransmission.automatic;

        }
        private void RefreshModels()
        {
            Models.Clear();
            foreach (var model in _model.CarModels)
            {
                if (model.ManufacturerId == SelectedManufacturer.Id)
                    Models.Add(model);
            }
        }

        #endregion

    }
}
