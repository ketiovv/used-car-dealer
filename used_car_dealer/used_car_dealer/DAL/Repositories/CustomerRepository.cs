using MySqlConnector;
using System;
using System.Collections.Generic;
using used_car_dealer.DAL.Entities;


namespace used_car_dealer.DAL.Repositories
{
    static class CustomerRepository
    {
        private const string allCustomersQuery = "SELECT * FROM customer";
        private const string addCustomerQuery = "INSERT INTO customer (customer_name, customer_last_name, customer_pesel, customer_phone_number, customer_postal_code, customer_city, customer_street, customer_home_number, customer_birth_date) VALUES";
        private const string deleteCustomerQuery = "DELETE FROM customer WHERE customer_id=";


        public static List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            using (var connection = DatabaseConnection.Instance.Connection)
            {
                var command = new MySqlCommand(allCustomersQuery, connection);
                try
                {
                    connection.Open();

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        customers.Add(new Customer(reader));
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Nie można otworzyć połączenia z bazą danych", ex);
                }
            }

            return customers;
        }

        public static bool AddCustomer(Customer customer)
        {
            bool condition = false;

            using (var connection = DatabaseConnection.Instance.Connection)
            {
                var command = new MySqlCommand($"{addCustomerQuery} {customer.ToInsert()}", connection);
                try
                {
                    connection.Open();

                    var id = command.ExecuteNonQuery();
                    condition = true;
                    customer.Id = (uint)command.LastInsertedId;

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Nie można otworzyć połączenia z bazą danych", ex);
                }
            }

            return condition;
        }

        public static bool DeleteCustomer(Customer customer)
        {
            bool condition = false;

            using (var connection = DatabaseConnection.Instance.Connection)
            {
                var command = new MySqlCommand($"{deleteCustomerQuery} {customer.Id}", connection);
                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                    condition = true;

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Nie można otworzyć połączenia z bazą danych", ex);
                }
            }
            return condition;
        }
    }
}
