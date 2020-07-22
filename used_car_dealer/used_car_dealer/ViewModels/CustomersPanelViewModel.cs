using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using used_car_dealer.core;
using used_car_dealer.DAL.Entities;
using used_car_dealer.DAL.Repositories;
using used_car_dealer.Models;

namespace used_car_dealer.ViewModels
{
    public class CustomersPanelViewModel: BindableBase
    {
        private Model _model;

        #region Properties

        private Customer _selectedCustomer = null;
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
        }

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        private string _pesel;
        public string Pesel
        {
            get => _pesel;
            set => SetProperty(ref _pesel, value);
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        private string _postalCode;
        public string PostalCode
        {
            get => _postalCode;
            set => SetProperty(ref _postalCode, value);
        }

        private string _city;
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        private string _street;
        public string Street
        {
            get => _street;
            set => SetProperty(ref _street, value);
        }

        private uint _homeNumber;
        public uint HomeNumber
        {
            get => _homeNumber;
            set => SetProperty(ref _homeNumber, value);
        }

        private string _birthDate;
        public string BirthDate
        {
            get => _birthDate;
            set => SetProperty(ref _birthDate, value);
        }

        #endregion

        public CustomersPanelViewModel(IApplicationCommands applicationCommands)
        {
            _model = new Model();
            _applicationCommands = applicationCommands;

            _customers = _model.Customers;

            _addCustomerCommand = new DelegateCommand(AddCustomer, AddCustomerPossible);
            _editCustomerCommand = new DelegateCommand(EditCustomer, EditCustomerPossible);
            _deleteCustomerCommand = new DelegateCommand(DeleteCustomer, DeleteCustomerPossible);

        }




        private IApplicationCommands _applicationCommands;
        public IApplicationCommands ApplicationCommands
        {
            get => _applicationCommands;
            set => SetProperty(ref _applicationCommands, value);
        }

        private ICommand _addCustomerCommand;
        public ICommand AddCustomerCommand
        {
            get => _addCustomerCommand;
            set => SetProperty(ref _addCustomerCommand, value);
        }
        private ICommand _editCustomerCommand;
        public ICommand EditCustomerCommand
        {
            get => _editCustomerCommand;
            set => SetProperty(ref _editCustomerCommand, value);
        }
        private ICommand _deleteCustomerCommand;
        public ICommand DeleteCustomerCommand
        {
            get => _deleteCustomerCommand;
            set => SetProperty(ref _deleteCustomerCommand, value);
        }

        public void AddCustomer()
        {
            var cust = new Customer(Name, LastName, Pesel, PhoneNumber, PostalCode, City, Street, HomeNumber, BirthDate);
            if (_model.AddCustomerToDatabase(cust))
            {
                ClearForm();
                MessageBox.Show("new customer in database!");
            }
        }

        public void EditCustomer()
        {

        }
        public void DeleteCustomer()
        {
            var cust = SelectedCustomer;
            if (_model.DeleteCustomerFromDatabase(cust))
            {
                MessageBox.Show($"customer with id:{cust.Id} deleted from database!");
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
