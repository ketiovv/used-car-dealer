using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using used_car_dealer.core;

namespace used_car_dealer.DAL.Entities
{
    public class Deal
    {
        #region Properties
        public uint? Id { get; set; }
        public DealType Type { get; set; }
        public uint Amount { get; set; }
        public string Date { get; set; }
        public uint CustomerId { get; set; }
        public uint CarId { get; set; }
        #endregion

        #region Ctor

        public Deal(MySqlDataReader reader)
        {
            Id = uint.Parse(reader["deal_id"].ToString());

            Enum.TryParse(reader["deal_type"].ToString(), out DealType dealType);
            Type = dealType;

            Amount = uint.Parse(reader["deal_amount"].ToString());
            Date = reader["deal_date"].ToString();
            CustomerId = uint.Parse(reader["deal_customer_id"].ToString());
            CarId = uint.Parse(reader["deal_car_id"].ToString());
        }

        public Deal(DealType dealType, uint amount, string date, uint customerId, uint carId)
        {
            Id = null;
            Type = dealType;
            Amount = amount;
            Date = date;
            CustomerId = customerId;
            CarId = carId;
        }
        public Deal(Deal deal)
        {
            Id = deal.Id;
            Type = deal.Type;
            Amount = deal.Amount;
            Date = deal.Date;
            CustomerId = deal.CustomerId;
            CarId = deal.CarId;
        }
        #endregion

        public string ToInsert()
        {
            return $"('{Type}',{Amount},'{Date}',{CustomerId},{CarId});";
        }
    }
}
