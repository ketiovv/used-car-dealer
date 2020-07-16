using Prism.Mvvm;
using System.Collections.ObjectModel;
using used_car_dealer.core;
using used_car_dealer.DAL.Entities;
using used_car_dealer.Models;

namespace used_car_dealer.ViewModels
{
    public class CustomersPanelViewModel: BindableBase
    {
        private Model _model;

        private Customer _selectedCustomer;
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

        private string _name = "test";
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
