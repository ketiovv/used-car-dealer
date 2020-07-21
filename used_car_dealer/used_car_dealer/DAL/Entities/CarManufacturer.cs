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

        //public CarManufacturer(string name, string origin)
        //{
        //    Id = null;
        //    Name = name.Trim();
        //    Origin = origin.Trim();
        //}

        //public CarManufacturer(CarManufacturer carManufacturer)
        //{
        //    Id = carManufacturer.Id;
        //    Name = carManufacturer.Name;
        //    Origin = carManufacturer.Origin;
        //}
    }
}
