using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using used_car_dealer.DAL.Entities;

namespace used_car_dealer.DAL.Repositories
{
    static class DealRepository
    {
        private const string allDealsQuery = "SELECT * FROM deal";
        private const string addDealQuery = "INSERT INTO deal (deal_type, deal_amount, deal_date, deal_customer_id, deal_car_id) VALUES";
        private const string deleteDealQuery = "DELETE FROM deal WHERE deal_id=";

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

        public static bool AddDeal(Deal deal)
        {
            bool condition = false;

            using (var connection = DatabaseConnection.Instance.Connection)
            {
                var command = new MySqlCommand($"{addDealQuery} {deal.ToInsert()}", connection);
                try
                {
                    connection.Open();

                    var id = command.ExecuteNonQuery();
                    condition = true;
                    deal.Id = (uint)command.LastInsertedId;

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Nie można otworzyć połączenia z bazą danych", ex);
                }
            }

            return condition;
        }
        public static bool DeleteDeal(Deal deal)
        {
            bool condition = false;

            using (var connection = DatabaseConnection.Instance.Connection)
            {
                var command = new MySqlCommand($"{deleteDealQuery} {deal.Id}", connection);

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
