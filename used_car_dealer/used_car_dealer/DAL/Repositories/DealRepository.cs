using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using used_car_dealer.DAL.Entities;

namespace used_car_dealer.DAL.Repositories
{
    static class DealRepository
    {
        private const string allDealsQuery = "SELECT * FROM deal";
        private const string addDealQuery = "INSERT INTO car";
        private const string deleteDealQuery = "DELETE FROM car WHERE";

        public static List<Deal> GetAllDeals()
        {
            var deals = new List<Deal>();
            using (var connection = DatabaseConnection.Instance.Connection)
            {
                var command = new MySqlCommand(allDealsQuery, connection);
                try
                {
                    connection.Open();

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        deals.Add(new Deal(reader));
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Nie można otworzyć połączenia z bazą danych", ex);
                }
            }

            return deals;
        }
    }
}
