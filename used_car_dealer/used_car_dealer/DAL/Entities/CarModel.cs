using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace used_car_dealer.DAL.Entities
{
    public class CarModel
    {
        public uint? Id { get; set; }
        public string Name { get; set; }
        public uint ManufacturerId { get; set; }
    }
}
