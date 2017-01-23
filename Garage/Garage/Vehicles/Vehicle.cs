using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Vehicle
    {
        public int ParkingSlot { get; set; }
        public int RegisterNumber { get; set; }
        public string Color {get; set; }
        public string VehicleType { get; set; }
        public uint NumberOfWheels { get; set; }

        public Vehicle(int registerNumber, string color, string vehicleType, uint numberOfWheels)
        {
            RegisterNumber = registerNumber;
            Color = color;
            VehicleType = vehicleType;
            NumberOfWheels = numberOfWheels;
        }
    }
}
