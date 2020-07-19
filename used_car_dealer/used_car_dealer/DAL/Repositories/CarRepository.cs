using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using used_car_dealer.DAL.Entities;

namespace used_car_dealer.DAL.Repositories
{
    static class CarRepository
    {
        private const string allCarsQuery = "SELECT * FROM car";
        private const string addCarQuery = "INSERT INTO car";
        private const string deleteCarQuery = "DELETE FROM car WHERE";


        public static List<Car> GetAllCars()
        {
            var cars = new List<Car>();
            using (var connection = DatabaseConnection.Instance.Connection)
            {
                var commmand = new MySqlCommand(allCarsQuery, connection);
                try
                {
                    connection.Open();

                    var reader = commmand.ExecuteReader();
                    while (reader.Read())
                    {
                        cars.Add(new Car(reader));
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Nie można otworzyć połączenia z bazą danych", ex);
                }
            }
            return cars;
        }



    }
}
