using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using used_car_dealer.DAL.Entities;
using used_car_dealer.DAL.Repositories;

namespace used_car_dealer.Models
{
    class Model
    {
        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();
        public ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>();
        public ObservableCollection<Deal> Deals { get; set; } = new ObservableCollection<Deal>();

        public ObservableCollection<CarManufacturer> CarManufacturers { get; set; } = new ObservableCollection<CarManufacturer>();
        public ObservableCollection<CarModel> CarModels { get; set; } = new ObservableCollection<CarModel>();


        public Model()
        {
            var customers = CustomerRepository.GetAllCustomers();
            foreach (var customer in customers)
                Customers.Add(customer);

            var cars = CarRepository.GetAllCars();
            foreach (var car in cars)
            {
                Cars.Add(car);
            }
            var deals = DealRepository.GetAllDeals();
            foreach (var deal in deals)
            {
                Deals.Add(deal);
            }

            var manufacturers = CarManufacturerRepository.GetAllManufacturers();
            foreach (var manu in manufacturers)
            {
                CarManufacturers.Add(manu);
            }
            var models = CarModelRepository.GetAllModels();
            foreach (var model in models)
            {
                CarModels.Add(model);
            }
        }

        /// <summary>
        /// CUSTOMER
        /// </summary>
        public bool CustomerExistInRepo(Customer customer) => Customers.Contains(customer);
        public bool AddCustomerToDatabase(Customer customer)
        {
            if (!CustomerExistInRepo(customer))
            {
                if (CustomerRepository.AddCustomer(customer))
                {
                    Customers.Add(customer);
                    return true;
                }
            }
            MessageBox.Show("Customer already exist");
            return false;
        }
        public bool DeleteCustomerFromDatabase(Customer customer)
        {
            if (CustomerExistInRepo(customer))
            {
                if (CustomerRepository.DeleteCustomer(customer))
                {
                    Customers.Remove(customer);
                    return true;
                }
            }
            return false;
        }

        ///<summary>
        /// CAR
        /// </summary>


    }
}
