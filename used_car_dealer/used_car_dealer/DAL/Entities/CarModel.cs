using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace used_car_dealer.DAL.Entities
{
    public class CarModel
    {
        public uint? Id { get; set; }
        public string Name { get; set; }
        public uint ManufacturerId { get; set; }

        public CarModel(MySqlDataReader reader)
        {
            Id = uint.Parse(reader["model_id"].ToString());
            Name = reader["model_name"].ToString();
            ManufacturerId = uint.Parse(reader["model_manufacturer_id"].ToString());
        }
    }
}
