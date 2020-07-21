using System;
using System.Collections.Generic;
using Prism.Mvvm;
using System.Collections.ObjectModel;
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


        private string _selectedManufacturer;// = "<select>";
        public string SelectedManufacturer
        {
            get => _selectedManufacturer;
            set => SetProperty(ref _selectedManufacturer, value, RefreshModels);
        }


        private List<string> _manufacturers = new List<string>();
        public List<string> Manufacturers
        {
            get => _manufacturers;
            set => SetProperty(ref _manufacturers, value);
        }


        private string _selectedModel;// = "<select manufacturer>";

        public string SelectedModel
        {
            get => _selectedModel;
            set => SetProperty(ref (_selectedModel), value);
        }


        private List<string> _models = new List<string>();
        public List<string> Models
        {
            get => _models;
            set => SetProperty(ref _models, value);
        }

        // model

        private uint _price = 20000;
        public uint Price
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


        private uint _mileage = 150000;
        public uint Mileage
        {
            get => _mileage;
            set => SetProperty(ref _mileage, value);
        }


        private uint _yearFrom = 2010;
        public uint YearFrom
        {
            get => _yearFrom;
            set => SetProperty(ref _yearFrom, value);
        }


        private uint _engineCapacity = 1600;
        public uint EngineCapacity
        {
            get => _engineCapacity;
            set => SetProperty(ref _engineCapacity, value);
        }


        private CarFuel _fuel = CarFuel.petrol;
        public CarFuel Fuel
        {
            get => _fuel;
            set => SetProperty(ref _fuel, value);
        }


        private uint _power = 120;
        public uint Power
        {
            get => _power;
            set => SetProperty(ref _power, value);
        }


        private CarTransmission _transmission = CarTransmission.manual;
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
            //_manufacturers.Add("<select>");
            //_models.Add("<select manufacturer>");
            foreach (var manufacturer in _model.CarManufacturers)
            {
                _manufacturers.Add(manufacturer.Name);
            }

            _addCarCommand = new DelegateCommand(AddCar, AddCarPossible);
            _editCarCommand = new DelegateCommand(EditCar, EditCarPossible);
            _deleteCarCommand = new DelegateCommand(DeleteCar, DeleteCarPossible);
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
            var car = new Car(Convert.ToUInt32(FindModelByName(SelectedModel).Id), Price, Type, Color,
                Mileage, YearFrom, EngineCapacity, Fuel, Power, Transmission);
            if (_model.AddCarToDatabase(car))
            {
                //    ClearForm();
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

        public bool AddCarPossible()
        {
            return true;
        }

        public bool EditCarPossible()
        {
            return false;
        }
        public bool DeleteCarPossible()
        {
            return true;
        }

        public void ClearForm()
        {

        }
        private void RefreshModels()
        {
            Models.Clear();
            //Models.Add("<select>");
            //SelectedModel = "<select>";

            CarManufacturer currentManufacturer = FindManufacturerByName(SelectedManufacturer);

            foreach (var model in _model.CarModels)
            {
                if (model.ManufacturerId == currentManufacturer.Id)
                    Models.Add(model.Name);
            }

        }
        //private void DeleteDefaultSelector()
        //{
        //    Models.Remove("<select>");
        //}

        private CarManufacturer FindManufacturerByName(string name)
        {
            CarManufacturer appropriateManufacturer = null;
            foreach (var manufacturer in _model.CarManufacturers)
            {
                if (manufacturer.Name.Equals(name))
                {
                    appropriateManufacturer = manufacturer;
                    return appropriateManufacturer;
                }

            }
            return null;
        }

        private CarModel FindModelByName(string name)
        {
            CarModel appropriateModel = null;
            foreach (var model in _model.CarModels)
            {
                if (model.Name.Equals(name))
                {
                    appropriateModel = model;
                    return appropriateModel;
                }
            }

            return null;
        }
    }
}
