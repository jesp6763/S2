﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInheritence.Components;
using VehicleInheritence.Enums;

namespace VehicleInheritence
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create 4 different motorized vehicles
            MotorVehicle vehicle1 = new MotorVehicle("BMW", "E34", 1435.0f, 80.0f, 195, new Powertrain(new Transmission(5, ETransmissionType.Manual)), EFuelType.Benzin, EWheelDrive.RWD);
            MotorVehicle vehicle2 = new MotorVehicle("Ford", "Escort mk2", 1243.0f, 76.0f, 243, new Powertrain(new Transmission(5, ETransmissionType.Manual)), EFuelType.Benzin, EWheelDrive.AWD);
            MotorVehicle vehicle3 = new MotorVehicle("Lamborghini", "Hurricane", 1105.0f, 65.0f, 323, new Powertrain(new Transmission(6)), EFuelType.Benzin, EWheelDrive.FWD);
            MotorVehicle vehicle4 = new MotorVehicle("Ford", "Raptor F-150", 1724.0f, 95.0f, 154, new Powertrain(new Transmission(6, ETransmissionType.Manual)), EFuelType.Benzin, EWheelDrive.AWD);

            PrintMotorVehicleSpecs(vehicle1);
            vehicle1.Accelerate();
            PrintMotorVehicleSpecs(vehicle2);
            vehicle2.Accelerate();
            PrintMotorVehicleSpecs(vehicle3);
            vehicle3.Accelerate();
            PrintMotorVehicleSpecs(vehicle4);
            vehicle4.Accelerate();

            Console.WriteLine(); // Space
            // Create 2 bicycles
            MountainBike mountainBike = new MountainBike("Lamingo", "Normandy R-2", 59, 6);
            RacingBike racingBike = new RacingBike("Raci", "RMaster M29", 34, 3);
            mountainBike.Accelerate();
            racingBike.Accelerate();

            Console.ReadKey();
        }

        private static void PrintMotorVehicleSpecs(MotorVehicle vehicle)
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine($"Manufacturer:\t\t{vehicle.Manufacturer}");
            Console.WriteLine($"Model:\t\t\t{vehicle.Model}");
            Console.WriteLine($"Weight:\t\t\t{vehicle.Weight:N0} kg");
            Console.WriteLine($"Top Speed:\t\t{vehicle.TopSpeed} km/h");
            Console.WriteLine($"Transmission Type:\t{vehicle.Powertrain.Transmission.TransmissionType}");
            Console.WriteLine($"Fuel Type:\t\t{vehicle.FuelType}");
            Console.WriteLine($"Fuel Capacity:\t\t{vehicle.FuelCapacity} litres");
            Console.WriteLine($"Wheel-drive layout:\t{vehicle.WheelDrive}");
            Console.WriteLine($"Gears:\t\t\t{vehicle.Powertrain.Transmission.Gears}");
        }
    }
}