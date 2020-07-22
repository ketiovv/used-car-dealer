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
        private const string addCarQuery = "INSERT INTO car (car_model_id, car_price, car_type, car_color, car_mileage, car_year_from, car_engine_capacity, car_fuel, car_power, car_transmission) VALUES";
        private const string deleteCarQuery = "DELETE FROM car WHERE car_id=";


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

        public static bool AddCar(Car car)
        {
            bool condition = false;

            using (var connection = DatabaseConnection.Instance.Connection)
            {
                var command = new MySqlCommand($"{addCarQuery} {car.ToInsert()}", connection);
                try
                {
                    connection.Open();

                    var id = command.ExecuteNonQuery();
                    condition = true;
                    car.Id = (uint)command.LastInsertedId;

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Nie można otworzyć połączenia z bazą danych", ex);
                }
            }

            return condition;
        }
        public static bool DeleteCar(Car car)
        {
            bool condition = false;

            using (var connection = DatabaseConnection.Instance.Connection)
            {
                var command = new MySqlCommand($"{deleteCarQuery} {car.Id}", connection);
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
