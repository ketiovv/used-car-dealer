using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using used_car_dealer.core;

namespace used_car_dealer.DAL.Entities
{
    public class Car
    {
        #region Properties
        public uint? Id { get; set; }
        public uint ModelId { get; set; }
        public uint Price { get; set; }
        public CarType Type { get; set; }
        public string Color { get; set; }
        public uint Mileage { get; set; }
        public uint YearFrom { get; set; }
        public uint EngineCapacity { get; set; }
        public CarFuel Fuel { get; set; }
        public uint Power { get; set; }
        public CarTransmission Transmission { get; set; }
        #endregion

        #region Ctor
        public Car(MySqlDataReader reader)
        {
            Id = uint.Parse(reader["car_id"].ToString());
            ModelId = uint.Parse(reader["car_model_id"].ToString());
            Price = uint.Parse(reader["car_price"].ToString());

            Enum.TryParse(reader["car_type"].ToString(), out CarType carType);
            Type = carType;

            Color = reader["car_color"].ToString();
            Mileage = uint.Parse(reader["car_mileage"].ToString());
            YearFrom = uint.Parse(reader["car_year_from"].ToString());
            EngineCapacity = uint.Parse(reader["car_engine_capacity"].ToString());

            Enum.TryParse(reader["car_fuel"].ToString(), out CarFuel carFuel);
            Fuel = carFuel;

            Power = uint.Parse(reader["car_power"].ToString());

            Enum.TryParse(reader["car_transmission"].ToString(), out CarTransmission carTransmission);
            Transmission = carTransmission;
        }
        public Car(uint modelId, uint price, CarType carType, string carColor, uint carMileage, uint carYearFrom,
            uint carEngineCapacity, CarFuel carFuel, uint carPower, CarTransmission carTransmission)
        {
            Id = null;
            ModelId = modelId;
            Price = price;
            Type = carType;
            Color = carColor.Trim();
            Mileage = carMileage;
            YearFrom = carYearFrom;
            EngineCapacity = carEngineCapacity;
            Fuel = carFuel;
            Power = carPower;
            Transmission = carTransmission;
        }

        public Car(Car car)
        {
            Id = car.Id;
            ModelId = car.ModelId;
            Price = car.Price;
            Type = car.Type;
            Color = car.Color;
            Mileage = car.Mileage;
            YearFrom = car.YearFrom;
            EngineCapacity = car.EngineCapacity;
            Fuel = car.Fuel;
            Power = car.Power;
            Transmission = car.Transmission;
        }
        #endregion

        #region Methods

        public string ToInsert()
        {
            return $"";
        }

        public override string ToString()
        {
            return $"{Id}";
        }

        #endregion
    }
}
