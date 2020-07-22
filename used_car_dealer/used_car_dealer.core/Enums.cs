using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace used_car_dealer.core
{
    public enum CarType
    {
        coupe,
        hatchback,
        minivan,
        pickup,
        sedan,
        suv,
        van,
        wagon
    }
    public enum CarFuel
    {
        diesel,
        petrol,
        petrol_gas,
        petrol_electric,
        electric
    }
    public enum CarTransmission
    {
        automatic,
        semi_automatic,
        manual
    }
    public enum DealType
    {
        sale,
        purchase
    }
}
