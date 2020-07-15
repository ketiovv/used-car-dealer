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
        public ObservableCollection<Customer> Customers { get; set; }

        public Model()
        {
            Customers = new ObservableCollection<Customer>();

            ///<summary>
            /// Get all customers from database
            /// </summary>
            var customers = CustomerRepository.GetAllCustomers();
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }

            ///<summary>
            /// itd.. to samo dla reszty
            /// </summary>
        }
    }
}
