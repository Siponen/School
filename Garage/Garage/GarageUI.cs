using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class GarageUI
    {
        GarageHandler garageHandler;
        public bool IsDone { get; private set; }

        public GarageUI(GarageHandler garageHandler)
        {
            this.garageHandler = garageHandler;
            IsDone = false;
        }

        public void MainMenu()
        {
            Welcome();
            PrintNumberOfVacantSlots();
            Console.WriteLine("1. Check in vehicle");
            Console.WriteLine("2. Check out vehicle");
            Console.WriteLine("3. Find vehicle");
            Console.WriteLine("4. Print all vehicles in garage");
            Console.WriteLine("5. Count all vehicles by type");
            Console.WriteLine("6. Create new garage");
            Console.WriteLine("7. Fill garage randomly");
            Console.WriteLine("0. Quit");
            
            char input = Commons.AskForKey("Choose an option: ");
            Console.WriteLine();
            switch (input)
            {
                case '1': CheckInVehicle(); break;
                case '2': CheckOutVehicle(); break;
                case '3': FindVehicleMenu(); break;
                case '4': PrintAllVehicles(); break;
                case '5': CountVehiclesByType(); break;
                case '6': NewGarage(); break;
                case '7': FillGarage(); break;
                case '0': IsDone = true; break;
            }
        }

        void Welcome() => Console.WriteLine($"Welcome to {garageHandler.GarageName} Garage!");
        void PrintNumberOfVacantSlots() => Console.WriteLine(
            $"There's {garageHandler.GarageCapacity - garageHandler.Count} vacant parking slots\n");

        void CheckInVehicle()
        {
            if(garageHandler.IsFull)
            {
                Console.WriteLine("Sorry! The garage is full");
                return;
            }

            Console.Clear();
            Console.WriteLine("Check in vehicle");
            int registerNumber = Commons.AskForInt("Enter vehicle's register number: ");
            string color = Commons.AskForString("Enter vehicle's color: ");
            string vehicleType = Commons.AskForString("Enter vehicle's type [Airplane, Boat, Bus, Car, Motorcycle]: ");

            bool result = false;
            switch (vehicleType)
            {
                case "Airplane":
                    uint numberOfEngines = Commons.AskForUInt("Enter airplane's number of engines: ");
                    result = garageHandler.AddVehicle(new Airplane(registerNumber, color, numberOfEngines));
                    break;
                case "Boat":
                    uint length = Commons.AskForUInt("Enter boat's length: ");
                    result = garageHandler.AddVehicle(new Boat(registerNumber, color, length));
                    break;

                case "Bus":
                    uint numberOfSeats = Commons.AskForUInt("Enter bus's number of seats: ");
                    result = garageHandler.AddVehicle(new Bus(registerNumber, color, numberOfSeats));
                    break;

                case "Car":
                    int fuelType = Commons.AskForInt("Enter car's fuel type: ");
                    result = garageHandler.AddVehicle(new Car(registerNumber, color, (FuelType)fuelType));
                    break;

                case "Motorcycle":
                    uint cylinderVolume = Commons.AskForUInt("Enter motorcycle's cylinder volume: ");
                    result = garageHandler.AddVehicle(new Motorcycle(registerNumber, color, cylinderVolume));
                    break;
                default:
                    Console.WriteLine("Invalid vehicle type");
                    return;
            }

            if (result)
                Console.WriteLine($"{vehicleType} has been parked!");
            else
                Console.WriteLine($"Error failed to park {vehicleType}");
        }

        void CheckOutVehicle()
        {
            if(garageHandler.IsEmpty)
            {
                Console.WriteLine("");
                return;
            }

            Console.Clear();
            Console.WriteLine("Check out vehicle");
            int registerNumber = Commons.AskForInt("Enter vehicle's register number ");

            if(garageHandler.RemoveVehicle(registerNumber))
                Console.WriteLine("Vehicle has been removed.");
            else
                Console.WriteLine("Vehicle couldn't be removed!");
        }

        void FindVehicleMenu()
        {
            Console.Clear();
            Console.WriteLine("Find vehicle menu:");
            Console.WriteLine("1. Find vehicle by register number");
            Console.WriteLine("2. Find vehicle by type");
            Console.WriteLine("3. Find vehicle by color");
            Console.WriteLine("4. Find vehicle by type and color");

            char input = Commons.AskForKey("Choose an option: ");
            switch (input)
            {
                case '1': FindVehicleByID(); break;
                case '2': FindVehicleByType();break;
                case '3': FindVehicleByColor(); break;
                case '4': FindVehicleByTypeAndColor(); break;
                default: Console.WriteLine("Invalid input!");
                    break;
            }
        }

        void FindVehicleByID()
        {
            Console.Clear();
            Console.WriteLine("Find your vehicle: ");
            int registerNumber = Commons.AskForInt("Input your vehicle's register number: ");
            Vehicle vehicle = garageHandler.FindVehicleByID(registerNumber);

            if (vehicle != null)
            {
                int location = garageHandler.FindVehicleLocation(registerNumber);
                Console.WriteLine($"Your {vehicle.VehicleType.ToLower()} is found at parking slot {location}.");
            }
            else
                Console.WriteLine("This register number doesn't exist");
        }

        void FindVehicleByType()
        {
            Console.Clear();
            Console.WriteLine("Find vehicles by type: ");

            string vehicleType = Commons.AskForString("Input the vehicle's type: ");
            var vehicles = garageHandler.GetVehiclesByType(vehicleType);

            Console.WriteLine("Found matches:");
            PrintLinq(vehicles);
        }

        void FindVehicleByColor()
        {
            Console.Clear();
            Console.WriteLine("Find vehicles by color: ");

            string color = Commons.AskForString("Input the vehicle's color: ");
            var vehicles = garageHandler.GetVehiclesByColor(color);

            Console.WriteLine("Found matches:");
            PrintLinq(vehicles);
        }

        void FindVehicleByTypeAndColor()
        {
            Console.Clear();
            Console.WriteLine("Find vehicle by type and color\n");
            string type = Commons.AskForString("Input a vehicle type: ");
            string color = Commons.AskForString("Input a color: ");
            Console.WriteLine();
            var vehicles = garageHandler.GetVehiclesByTypeAndColor(type, color);
            PrintLinq(vehicles);
        }
        
        void PrintLinq(IEnumerable<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"Parking slot {vehicle.ParkingSlot}: {vehicle.RegisterNumber}, {vehicle.VehicleType}, {vehicle.Color}, {vehicle.NumberOfWheels}");
            }
        }

        void PrintAllVehicles()
        {
            Console.Clear();
            var vehicles = garageHandler.GetAllVehicles();
            Console.WriteLine("Display all vehicles: ");
            PrintLinq(vehicles);
        }

        void AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Administrator menu:");
            Console.WriteLine("1. Create new garage");
            Console.WriteLine("2. Fill garage randomly");

            char input = Commons.AskForKey("Choose an option: ");
            Console.WriteLine();
            switch(input)
            {
                case '1': NewGarage(); break;
                case '2': FillGarage(); break;
            }
        }

        void CountVehiclesByType()
        {
            Console.Clear();
            Console.WriteLine("Vehicle count by type: ");
            foreach (var vehicle in garageHandler.CountVehicles())
            {
                Console.WriteLine($"{vehicle.VehicleType}: {vehicle.Count}");
            }
        }

        void NewGarage()
        {
            Console.Clear();
            Console.WriteLine("Create a new garage");
            string name = Commons.AskForString("Give the new garage a name: ");
            uint numberOfSlots = Commons.AskForUInt("How many parking slots is there going to be in the garage: ");

            if(numberOfSlots > 0)
                garageHandler.NewGarage(name,numberOfSlots);
            else
            {
                Console.WriteLine("Error the requested garage has no parking slots!");
                return;
            }
        }

        void FillGarage()
        {
            if (garageHandler.Count > 0)
            {
                Console.WriteLine("This garage has already been filled!");
                return;
            }

            Console.WriteLine("Filling garage...");
            Random random = new Random(DateTime.Now.Millisecond);
            int numberOfVehicles = random.Next((int)(garageHandler.GarageCapacity*0.5), (int)garageHandler.GarageCapacity);

            string[] vehicleTypes = { "Airplane", "Boat", "Bus", "Car", "Motorcycle" };
            string[] colors = { "Black", "Red", "Green", "Orange", "Blue", "Brown", "Yellow", "White" };

            for(int i=0; i < numberOfVehicles; ++i)
            {
                int regNumber = random.Next(999);
                int type = random.Next(vehicleTypes.Length);
                int color = random.Next(colors.Length);

                switch(vehicleTypes[type])
                {
                    case "Airplane":
                        uint numEngines = (uint)random.Next(10);
                        garageHandler.AddVehicle(new Airplane(regNumber,colors[color],numEngines));
                        break;
                    case"Boat":
                        uint length = (uint)random.Next(100);
                        garageHandler.AddVehicle(new Boat(regNumber,colors[color],length));
                        break;
                    case "Bus":
                        uint numSeats = (uint)random.Next(500);
                        garageHandler.AddVehicle(new Bus(regNumber, colors[color], numSeats));
                        break;
                    case "Car":
                        FuelType fuelType = (FuelType)random.Next(2);
                        garageHandler.AddVehicle(new Car(regNumber, colors[color], fuelType));
                        break;
                    case "Motorcycle":
                        uint cylinderVolume = (uint)random.Next(200);
                        garageHandler.AddVehicle(new Motorcycle(regNumber,colors[color],cylinderVolume));
                        break;
                }
            }
        }
    }
}
