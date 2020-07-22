using MySqlConnector;

namespace used_car_dealer.DAL.Entities
{
    public class CarManufacturer
    {
        public uint? Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }

        public CarManufacturer(MySqlDataReader reader)
        {
            Id = uint.Parse(reader["manufacturer_id"].ToString());
            Name = reader["manufacturer_name"].ToString();
            Origin = reader["manufacturer_origin"].ToString();
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
