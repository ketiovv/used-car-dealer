using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using used_car_dealer.DAL.Entities;

namespace used_car_dealer.DAL.Repositories
{
    static class CarManufacturerRepository
    {
        private const string allManufacturersQuery = "SELECT * FROM car_manufacturer";

        public static List<CarManufacturer> GetAllManufacturers()
        {
            var manufacturers = new List<CarManufacturer>();
            using (var connection = DatabaseConnection.Instance.Connection)
            {
                var command = new MySqlCommand(allManufacturersQuery, connection);
                try
                {
                    connection.Open();

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        manufacturers.Add(new CarManufacturer(reader));
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Nie można otworzyć połączenia z bazą danych", ex);
                }

            }
            return manufacturers;
        }
    }
}
