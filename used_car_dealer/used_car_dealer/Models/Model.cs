using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using used_car_dealer.DAL.Entities;
using used_car_dealer.DAL.Repositories;

namespace used_car_dealer.Models
{
    class Model
    {
        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

        public Model()
        {
            var customers = CustomerRepository.GetAllCustomers();
            foreach (var customer in customers)
                Customers.Add(customer);
        }

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
            return false;
        }

    }
}
