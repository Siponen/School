using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Car : Vehicle
    {
        FuelType FuelType { get; set; }

        public Car(int registerNumber, string color, FuelType fuelType) : base(registerNumber,color,"Car",4)
        {
            FuelType = fuelType;
        }
    }
}
