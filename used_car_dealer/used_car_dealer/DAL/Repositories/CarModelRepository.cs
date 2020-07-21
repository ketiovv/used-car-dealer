using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using used_car_dealer.DAL.Entities;

namespace used_car_dealer.DAL.Repositories
{
    static class CarModelRepository
    {
        private const string allModelsRepository = "SELECT * FROM car_model";

        public static List<CarModel> GetAllModels()
        {
            var models = new List<CarModel>();
            using (var connection = DatabaseConnection.Instance.Connection)
            {
                var command = new MySqlCommand(allModelsRepository, connection);
                try
                {
                    connection.Open();

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        models.Add(new CarModel(reader));
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Nie można otworzyć połączenia z bazą danych", ex);
                }

            }
            return models;
        }
    }
}
