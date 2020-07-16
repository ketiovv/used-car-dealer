using MySqlConnector;
using System;
using System.Collections.Generic;
using used_car_dealer.DAL.Entities;


namespace used_car_dealer.DAL.Repositories
{
    static class CustomerRepository
    {
        private const string allCustomersQuery = "SELECT * FROM customer";
        private const string addCustomerQuery = "INSERT INTO 'customer'" +
                                                "'customer_name', 'customer_lastname','customer_pesel'," +
                                                "'customer_phone_number','customer_postal_code'," +
                                                "'customer_city','customer_street','customer_home_number'," +
                                                "'customer_birth_date' VALUES ";

        public static List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
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
                    throw new Exception("Nie można połączyć z bazą danych", ex);
                }
            }

            return customers;
        }
    }
}
