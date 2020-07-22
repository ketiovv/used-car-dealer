using System;
using System.Collections.Generic;
using Prism.Mvvm;
using System.Collections.ObjectModel;
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
    public class DealsPanelViewModel: BindableBase
    {
        private Model _model;

        private Deal _selectedDeal;
        public Deal SelectedDeal
        {
            get => _selectedDeal;
            set => SetProperty(ref _selectedDeal, value);
        }


        private ObservableCollection<Deal> _deals;
        public ObservableCollection<Deal> Deals
        {
            get => _deals;
            set => SetProperty(ref _deals, value);
        }

        private DealType _selectedDealType = DealType.purchase;
        public DealType SelecteDealType
        {
            get => _selectedDealType;
            set => SetProperty(ref _selectedDealType, value);
        }


        private uint _amount;
        public uint Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }


        private string _date;
        public string Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }


        private List<Customer> _customers = new List<Customer>();
        public List<Customer> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }


        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
        }


        private List<Car> _cars = new List<Car>();
        public List<Car> Cars
        {
            get => _cars;
            set => SetProperty(ref _cars, value);
        }


        private Car _selectedCar;
        public Car SelectedCar
        {
            get => _selectedCar;
            set => SetProperty(ref _selectedCar, value);
        }



        public DealsPanelViewModel(IApplicationCommands applicationCommands)
        {
            _model = new Model();
            _applicationCommands = applicationCommands;
            _deals = _model.Deals;
            _cars = _model.Cars.ToList();
            _customers = _model.Customers.ToList();

            AddDealCommand = new DelegateCommand(AddDeal, AddDealPossible);
            EditDealCommand = new DelegateCommand(EditDeal, EditDealPossible);
            DeleteDealCommand = new DelegateCommand(DeleteDeal, DeleteDealPossible);
        }

        private IApplicationCommands _applicationCommands;
        public IApplicationCommands ApplicationCommands
        {
            get => _applicationCommands;
            set => SetProperty(ref _applicationCommands, value);
        }

        private ICommand _addDealCommand;
        public ICommand AddDealCommand
        {
            get => _addDealCommand;
            set => SetProperty(ref _addDealCommand, value);
        }


        private ICommand _editDealCommand;
        public ICommand EditDealCommand
        {
            get => _editDealCommand;
            set => SetProperty(ref _editDealCommand, value);
        }

        private ICommand _deleteDealCommand;
        public ICommand DeleteDealCommand
        {
            get => _deleteDealCommand;
            set => SetProperty(ref _deleteDealCommand, value);
        }

        private void AddDeal()
        {
            var deal = new Deal(SelecteDealType, Amount, Date, Convert.ToUInt32(SelectedCustomer.Id), Convert.ToUInt32(SelectedCar.Id));
            if (_model.AddDealToDatabase(deal))
            {
                MessageBox.Show("new deal in database");
            }
        }


        private void EditDeal()
        {

        }


        private void DeleteDeal()
        {
            var deal = SelectedDeal;
            if (_model.DeleteDealFromDatabase(deal))
            {
                MessageBox.Show($"deal with id:{deal.Id} deleted from db");
            }
        }

        public bool AddDealPossible()
        {
            return true;
        }

        public bool EditDealPossible()
        {
            return false;
        }
        public bool DeleteDealPossible()
        {
            return true;
        }
    }
}
