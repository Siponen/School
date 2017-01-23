using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class GarageHandler
    {
        Garage<Vehicle> garage;

        public GarageHandler(string name, uint numberOfSlots)
        {
            NewGarage(name, numberOfSlots);
        }

        public string GarageName { get { return garage.Name; } }
        public uint GarageCapacity { get { return garage.Capacity; } }
        public uint Count { get { return garage.Count; } }
        public bool IsFull { get; private set; }
        public bool IsEmpty { get; private set; }

        public void NewGarage(string name, uint numberOfSlots)
        {
            garage = new Garage<Vehicle>(name, numberOfSlots);
        }

        public bool AddVehicle(Vehicle vehicle)
        {
            if (garage.Count >= garage.Capacity)
            {
                Console.WriteLine("Failed to add vehicle, garage is already full!");
                return false;
            }

            bool success = garage.Add(vehicle);
            if (success)
            {
                if (garage.Count == GarageCapacity)
                    IsFull = true;
                else if ((garage.Count != 0) && (IsEmpty == true))
                    IsEmpty = false;
            }
            return success;
        }
        public bool RemoveVehicle(int registerNumber)
        {
            bool succeeded = false;
            if (garage.Count == 0) return succeeded;

            succeeded = garage.Remove(registerNumber);
            if (succeeded && garage.Count == 0) IsEmpty = true;

            return succeeded;
        }

        public bool Contains(int registerNumber)
        {
            foreach (var vehicle in garage.Vehicles)
            {
                if (vehicle?.RegisterNumber == registerNumber) return true;
            }
            return false;
        }

        public Vehicle FindVehicleByID(int registerNumber)
        {
            foreach (var item in garage.Vehicles)
            {
                if (item?.RegisterNumber == registerNumber) return item;
            }
            return null;
        }
        public int FindVehicleLocation(int registerNumber)
        {
            foreach (var item in garage.Vehicles)
            {
                if (item?.RegisterNumber == registerNumber) return item.ParkingSlot;
            }

            return -1;
        }

        public IEnumerable<Vehicle> GetVehiclesByType(string vehicleType)
        {
            return garage.Vehicles.Where(v => v?.VehicleType == vehicleType);
        }
        public IEnumerable<Vehicle> GetVehiclesByColor(string color)
        {
           return garage.Vehicles.Where(v => v?.Color == color);
        }
        public IEnumerable<Vehicle> GetVehiclesByTypeAndColor(string vehicleType, string color)
        {
            return garage.Vehicles
                .Where(v => v?.VehicleType == vehicleType && v?.Color == color);
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return garage.Vehicles.Where(v => v != null);
        }

        public IEnumerable<CountVehicles> CountVehicles()
        {
            return GetAllVehicles()
                .GroupBy(v => v?.VehicleType)
                .Select(g => new CountVehicles { VehicleType = g.Key, Count = g.Count() });
        }
        public int CountVehiclesByType(string vehicleType)
        {
            return garage.Where(v => v.VehicleType == vehicleType).Count();
        }
        public int CountVehiclesByColor(string color)
        {
            return garage.Where(v => v.Color == color).Count();
        }
    }
}
